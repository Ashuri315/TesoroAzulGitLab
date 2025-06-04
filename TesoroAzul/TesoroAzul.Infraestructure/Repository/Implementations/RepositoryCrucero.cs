using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Data;
using TesoroAzul.Infraestructure.Models;
using TesoroAzul.Infraestructure.Repository.Interfaces;

namespace TesoroAzul.Infraestructure.Repository.Implementations
{
    public class RepositoryCrucero : IRepositoryCrucero
    {
        private readonly TesoroAzulContext _context;

        public RepositoryCrucero(TesoroAzulContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Crucero>> ListAsync()
        {
            //SELECT * FROM Crucero
            var collection = await _context.Set<Crucero>().Include(barco => barco.IdBarcoNavigation).ToListAsync();
            return collection;
        }
        public async Task<Crucero> FindByIdAsync(int id)
        {
            //SELECT * FROM Crucero WHERE id = #
            //Debe incluir el itinerario (CruceroPuerto)
            //Debe incluir el calendario junto con los precios de las habitaciones
            var @object = await _context.Set<Crucero>()
                                        .Include(barco => barco.IdBarcoNavigation)
                                        .Include(itinerario => itinerario.CruceroPuerto)
                                            .ThenInclude(puerto => puerto.IdPuertoNavigation)
                                        .Include(calendario => calendario.Calendario)
                                            .ThenInclude(habitacionC => habitacionC.CalendarioHabitacion)
                                            .ThenInclude(habitacion => habitacion.IdHabitacionNavigation)
                                        .Where(x => x.IdCrucero == id)
                                        .FirstOrDefaultAsync();
            // Ordenar los detalles de CruceroPuerto por número de día
            if (@object != null)
            {
                @object.CruceroPuerto = @object.CruceroPuerto.OrderBy(cp => cp.NumeroDia).ToList();
            }

            return @object!;
        }

        public async Task<int> AddAsync(Crucero entity)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();
                await _context.Set<Crucero>().AddAsync(entity);

                await _context.SaveChangesAsync();
                await _context.Database.CommitTransactionAsync();

                return entity.IdBarco;
            }
            catch (DbUpdateException dbEx)
            {
                await _context.Database.RollbackTransactionAsync();
                throw new Exception($"Error de actualización de la base de datos: {dbEx.Message}", dbEx);
            }
            catch (Exception ex)
            {
                await _context.Database.RollbackTransactionAsync();
                throw new Exception($"Error general: {ex.Message}", ex);
            }
        }

        public async Task<ICollection<Crucero>> CruisesForHome()
        {
            //SELECT * FROM Crucero
            var collection = await _context.Set<Crucero>().Include(barco => barco.IdBarcoNavigation).Take(3).ToListAsync();
            return collection;
        }

        public async Task<ICollection<Crucero>> getCrucerosDisponibles()
        {
            DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);
            //SELECT * FROM Crucero
            var collection = await _context.Set<Crucero>()
                                        .Include(barco => barco.IdBarcoNavigation)
                                        .Include(calendario => calendario.Calendario.Where(x => x.FechaPago >= hoy))
                                            .ThenInclude(habitacionC => habitacionC.CalendarioHabitacion)
                                            .ThenInclude(habitacion => habitacion.IdHabitacionNavigation)
                                        .ToListAsync();


            return collection.
                Where(crucero => crucero.Calendario.Any(calendario => calendario.FechaPago >= hoy && calendario.CalendarioHabitacion.Any(habitacion => habitacion.Disponible > 0))).ToList();
                
        }
    }
}

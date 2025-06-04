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
    public class RepositoryReservaEncabezado : IRepositoryReservaEncabezado
    {
        private readonly TesoroAzulContext _context;

        public RepositoryReservaEncabezado(TesoroAzulContext context)
        {
            _context = context;
        }

        public async Task<ICollection<ReservaEncabezado>> ListAsync()
        {
            //SELECT * FROM ReservaEncabezado
            //Debe incluir el nombre del usuario
            var collection = await _context.Set<ReservaEncabezado>()
                                           .Include(u => u.IdUsuarioNavigation)
                                           .ToListAsync();
            return collection;
        }
        public async Task<ReservaEncabezado> FindByIdAsync(int id)
        {
            //SELECT * FROM ReservaEncabezado WHERE id = #
            var @object = await _context.Set<ReservaEncabezado>()
                                        .Include(calendario => calendario.Calendario)
                                            .ThenInclude(crucero => crucero.IdCruceroNavigation)
                                            .ThenInclude(cp => cp.CruceroPuerto)
                                            .ThenInclude(p => p.IdPuertoNavigation)
                                        .Include(calendario => calendario.Calendario)
                                            .ThenInclude(ch => ch.CalendarioHabitacion)
                                            .ThenInclude(ch => ch.IdHabitacionNavigation)
                                        .Include(detalle => detalle.ReservaDetalle)
                                            .ThenInclude(habitacion => habitacion.IdHabitacionNavigation)
                                        .Include(cxc => cxc.CuentaCobrar)
                                        .Include(rc => rc.ReservaComplemento)
                                            .ThenInclude(c => c.IdComplementoNavigation)
                                        .Include(u => u.IdUsuarioNavigation)
                                        .Where(x => x.IdReserva == id).FirstAsync();
            return @object!;
        }

        public async Task<int> AddAsync(ReservaEncabezado entity)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();
                await _context.Set<ReservaEncabezado>().AddAsync(entity);


                // Crear tabla habitaciones barco
                //foreach (var item in entity.BarcoHabitacion)
                //{
                //    await _context.Set<BarcoHabitacion>().AddAsync(item);
                //}
                await _context.SaveChangesAsync();

                await _context.Database.CommitTransactionAsync();

                return entity.IdReserva;
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
    }
}

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
    public class RepositoryHabitacion : IRepositoryHabitacion
    {
        private readonly TesoroAzulContext _context;

        public RepositoryHabitacion(TesoroAzulContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Habitacion>> ListAsync()
        {
            //SELECT * FROM Habitacion
            var collection = await _context.Set<Habitacion>().ToListAsync();
            return collection;
        }
        public async Task<Habitacion> FindByIdAsync(int id)
        {
            //SELECT * FROM Habitacion WHERE id = #
            var @object = await _context.Set<Habitacion>()
                                        .Where(x => x.IdHabitacion == id)
                                        .FirstAsync();
            return @object!;
        }
        public async Task<int> AddAsync(Habitacion entity)
        {
            await _context.Set<Habitacion>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.IdHabitacion;
        }

        public async Task UpdateAsync(Habitacion entity)
        {

            await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(string nombre)
        {
            return await _context.Set<Habitacion>()
                .AnyAsync(h => h.Nombre.ToLower() == nombre.ToLower());
        }

        public async Task<ICollection<Habitacion>> FindByNameAsync(string nombre)
        {
            var collection = await _context
                                         .Set<Habitacion>()
                                         .Where(p => p.Nombre.Contains(nombre))
                                         .ToListAsync();
            return collection;
        }

        public async Task<ICollection<Habitacion>> GetHabitacionesDisponibles(int idCrucero)
        {
            DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);
            //SELECT * FROM Crucero
            var collection = await _context.Set<Habitacion>()
                                        .Include(calendario => calendario.CalendarioHabitacion)
                                            .ThenInclude(habitacion => habitacion.IdHabitacionNavigation)
                                        .ToListAsync();


            return collection;

        }

        public Task<ICollection<Habitacion>> GetHabitacionesDisponibles()
        {
            throw new NotImplementedException();
        }

        //public async Task<ICollection<Habitacion>> GetHabitacionByIdBarco(int dBarco)
        //{
        //    var collection = await _context.Set<Habitacion>()
        //                            .Where(l => l..Any(c => c.IdCategoria == idCategoria))
        //                            .AsNoTracking()
        //                            .ToListAsync();
        //    return collection;
        //}
    }
}

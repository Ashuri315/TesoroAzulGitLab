using TesoroAzul.Infraestructure.Data;
using TesoroAzul.Infraestructure.Models;
using TesoroAzul.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesoroAzul.Infraestructure.Repository.Implementations
{
    public class RepositoryBarco : IRepositoryBarco
    {
        private readonly TesoroAzulContext _context;

        public RepositoryBarco(TesoroAzulContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Barco>> ListAsync()
        {
            //SELECT * FROM Barco
            var collection = await _context.Set<Barco>()
                                           .Include(Habitacion => Habitacion.BarcoHabitacion)
                                                .ThenInclude(barco => barco.IdHabitacionNavigation)
                                           .ToListAsync();
            return collection;
        }
        public async Task<Barco> FindByIdAsync(int id)
        {
            //SELECT * FROM Barco WHERE id = #
            //Debe incluir la lista de habitaciones
            var @object = await _context.Set<Barco>()
                                        .Include(Habitacion => Habitacion.BarcoHabitacion)
                                            .ThenInclude(barco => barco.IdHabitacionNavigation)
                                        .Where(x => x.IdBarco == id).FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<int> AddAsync(Barco entity)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();
                await _context.Set<Barco>().AddAsync(entity);
                

                // Crear tabla habitaciones barco
                //foreach (var item in entity.BarcoHabitacion)
                //{
                //    await _context.Set<BarcoHabitacion>().AddAsync(item);
                //}
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

        public async Task UpdateAsync(Barco entity)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();


                // Crear tabla habitaciones barco
                //foreach (var item in entity.BarcoHabitacion)
                //{
                //    await _context.Set<BarcoHabitacion>().AddAsync(item);
                //}
                await _context.SaveChangesAsync();

                await _context.Database.CommitTransactionAsync();
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

        public async Task<bool> AnyAsync(string nombre)
        {
            return await _context.Set<Barco>()
                .AnyAsync(h => h.Nombre.ToLower() == nombre.ToLower());
        }

        public async Task<ICollection<Barco>> FindByNameAsync(string nombre)
        {
            var collection = await _context
                                         .Set<Barco>()
                                         .Where(p => p.Nombre.Contains(nombre))
                                         .ToListAsync();
            return collection;
        }

        
    }
}

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
    public class RepositoryCuentaCobrar : IRepositoryCuentaCobrar
    {
        private readonly TesoroAzulContext _context;

        public RepositoryCuentaCobrar(TesoroAzulContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(CuentaCobrar entity)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();
                await _context.Set<CuentaCobrar>().AddAsync(entity);


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

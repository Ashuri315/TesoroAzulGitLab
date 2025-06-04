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
    public class RepositoryComplemento : IRepositoryComplemento
    {
        TesoroAzulContext _context;

        public RepositoryComplemento(TesoroAzulContext context)
        {
            _context = context;
        }

        public async Task<Complemento> FindByIdAsync(int id)
        {
            var @object = await _context.Set<Complemento>()
                                       .Where(x => x.IdComplemento == id)
                                       .FirstAsync();
            return @object!;
        }

        public async Task<ICollection<Complemento>> ListAsync()
        {
            var collection = await _context.Set<Complemento>()
                                            .ToListAsync();
            return collection;
        }
        public async Task<ICollection<Complemento>> GetComplementosHabitacion()
        {
            var collection = await _context.Set<Complemento>()
                                            .Where(x => x.PrecioAplicado == "Habitación")
                                            .ToListAsync();
            return collection;
        }

        public async Task<ICollection<Complemento>> GetComplementosPasajero()
        {
            var collection = await _context.Set<Complemento>()
                                            .Where(x => x.PrecioAplicado == "Persona")
                                            .ToListAsync();
            return collection;
        }

        public async Task<int> AddAsync(Complemento entity)
        {
            await _context.Set<Complemento>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.IdComplemento;
        }

        public async Task UpdateAsync(Complemento entity)
        {

            await _context.SaveChangesAsync();
        }
    }
}

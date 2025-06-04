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
    public class RepositoryPuerto : IRepositoryPuerto
    {
        private readonly TesoroAzulContext _context;

        public RepositoryPuerto(TesoroAzulContext context)
        {
            _context = context;
        }

        public async Task<Puerto> FindByIdAsync(int id)
        {
            //SELECT * FROM Barco WHERE id = #
            //Debe incluir la lista de habitaciones
            var @object = await _context.Set<Puerto>()
                                        .Where(x => x.IdPuerto == id).FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<Puerto>> FindByNameAsync(string nombre)
        {
            var collection = await _context
                                         .Set<Puerto>()
                                         .Where(p => p.Nombre.Contains(nombre))
                                         .ToListAsync();
            return collection;
        }
    }
}

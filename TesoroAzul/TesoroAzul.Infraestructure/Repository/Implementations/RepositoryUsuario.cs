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
    public class RepositoryUsuario : IRepositoryUsuario
    {

        private readonly TesoroAzulContext _context;

        public RepositoryUsuario(TesoroAzulContext context)
        {
            _context = context;
        }

        public async Task<string> AddAsync(Usuario entity)
        {
            await _context.Set<Usuario>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Email;
        }

        public async Task<Usuario> FindByIdAsync(string id)
        {
            var @object = await _context.Set<Usuario>().FindAsync(id);
            return @object!;
        }

        public async Task<Usuario> LoginAsync(string id, string contrasenna)
        {
            var @object = await _context.Set<Usuario>()
                                        .Where(p => p.Email == id && p.Contrasena == contrasenna)
                                        .FirstOrDefaultAsync();
            return @object!;
        }
    }
}

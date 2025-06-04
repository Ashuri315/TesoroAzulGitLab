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
    public class RepositoryCalendario : IRepositoryCalendario
    {
        private readonly TesoroAzulContext _context;

        public RepositoryCalendario(TesoroAzulContext context)
        {
            _context = context;
        }

        public async Task<Calendario> FindByIdAsync(DateOnly fechaInicio, int idCrucero)
        {
            var @object = await _context.Set<Calendario>()
                                        .Include(crucero => crucero.IdCruceroNavigation)
                                        .Where(f => f.FechaInicio == fechaInicio)
                                        .Where(c => c.IdCrucero == idCrucero)
                                        .FirstOrDefaultAsync();
            return @object!;
        }

    }
}

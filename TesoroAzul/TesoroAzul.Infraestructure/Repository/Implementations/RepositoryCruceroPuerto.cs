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
    public class RepositoryCruceroPuerto : IRepositoryCruceroPuerto
    {
        private readonly TesoroAzulContext _context;

        public RepositoryCruceroPuerto(TesoroAzulContext context)
        {
            _context = context;
        }

        public async Task<CruceroPuerto> FindPuertoSalida(int idCrucero)
        {
            var @object = await _context.Set<CruceroPuerto>()
                                        .Include(p => p.IdPuertoNavigation)
                                        .Where(d => d.NumeroDia == 1)
                                        .Where(c => c.IdCrucero == idCrucero)
                                        .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<CruceroPuerto> FindPuertoLlegada(int idCrucero)
        {
            var @object = await _context.Set<CruceroPuerto>()
                                        .Include(p => p.IdPuertoNavigation)
                                        .Where(d => d.NumeroDia == d.IdCruceroNavigation.CantidadDias)
                                        .Where(c => c.IdCrucero == idCrucero)
                                        .FirstOrDefaultAsync();
            return @object!;
        }
    }
}

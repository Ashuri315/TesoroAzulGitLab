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
    public class RepositoryReservaComplemento : IRepositoryReservaComplemento
    {
        private readonly TesoroAzulContext _context;

        public RepositoryReservaComplemento(TesoroAzulContext context)
        {
            _context = context;
        }

        public async Task<ReservaComplemento> FindByIdAsync(int idReserva, int idComplemento)
        {
            var @object = await _context.Set<ReservaComplemento>()
                                        .Include(c => c.IdComplementoNavigation)
                                        .Where(r => r.IdReserva == idReserva)
                                        .Where(c => c.IdComplemento == idComplemento)
                                        .FirstOrDefaultAsync();
            return @object!;
        }
    }
}

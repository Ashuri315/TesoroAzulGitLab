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
    public class RepositoryBarcoHabitacion : IRepositoryBarcoHabitacion
    {
        private readonly TesoroAzulContext _context;

        public RepositoryBarcoHabitacion(TesoroAzulContext context)
        {
            _context = context;
        }

        public async Task<ICollection<BarcoHabitacion>> HabitacionesByBarcoId(int id)
        {
            var response = await _context.Set<BarcoHabitacion>()
                           .Include(h => h.IdHabitacionNavigation)
                           .Where(p => p.IdBarco == id).ToListAsync();

            return response;

        }
    }
}

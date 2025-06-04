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
    public class RepositoryCalendarioHabitacion : IRepositoryCalendarioHabitacion
    {
        TesoroAzulContext _context;

        public RepositoryCalendarioHabitacion(TesoroAzulContext context)
        {
            _context = context;
        }

        public async Task<ICollection<CalendarioHabitacion>> getHabitacionesDisponibles(int idCrucero, DateOnly fechaInicio)
        {
            DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);
            //SELECT * FROM Crucero
            var collection = await _context.Set<CalendarioHabitacion>()
                             .Include(calendario => calendario.Calendario)
                             .Include(habitacion => habitacion.IdHabitacionNavigation)
                             .Where(x => x.Calendario.FechaPago >= hoy
                                      && x.Disponible > 0
                                      && x.IdCrucero == idCrucero
                                      && x.Calendario.FechaInicio == fechaInicio)
                             .ToListAsync();


            return collection;
        }

        public async Task UpdateAsync(CalendarioHabitacion entity)
        {
            await _context.SaveChangesAsync();
        }

        public async Task<CalendarioHabitacion> getCalendarioHabitacion(int idHabitacion, int idCrucero, DateOnly fechaInicio)
        {
            var calendarioHabitacion = await _context.Set<CalendarioHabitacion>()
                .Include(habitacion => habitacion.IdHabitacionNavigation)
                .Where(ch => ch.FechaInicio == fechaInicio && ch.IdHabitacion == idHabitacion && ch.IdCrucero == idCrucero)
                   .FirstOrDefaultAsync();

            return calendarioHabitacion!;
        }
    }
}

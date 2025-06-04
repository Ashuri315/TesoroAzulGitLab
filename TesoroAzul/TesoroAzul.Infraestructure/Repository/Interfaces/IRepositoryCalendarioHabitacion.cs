using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryCalendarioHabitacion
    {
        Task<ICollection<CalendarioHabitacion>> getHabitacionesDisponibles(int idCrucero, DateOnly fechaInicio);
        Task<CalendarioHabitacion> getCalendarioHabitacion (int idHabitacion, int idCrucero, DateOnly fechaInicio);
        Task UpdateAsync(CalendarioHabitacion entity);
    }
}

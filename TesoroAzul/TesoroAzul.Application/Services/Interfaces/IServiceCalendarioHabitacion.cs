using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;
using TesoroAzul.Application.DTOs;

namespace TesoroAzul.Application.Services.Interfaces
{
    public interface IServiceCalendarioHabitacion
    {
        Task<ICollection<CalendarioHabitacionDTO>> getHabitacionesDisponibles(int idCrucero, DateOnly fechaInicio);
        Task<CalendarioHabitacionDTO> getCalendarioHabitacion(int idHabitacion, int idCrucero, DateOnly fechaInicio);
        Task UpdateAsync(int idHabitacion, int idCrucero, DateOnly fechaInicio, CalendarioHabitacionDTO calendarioHabitacion);
    }
}

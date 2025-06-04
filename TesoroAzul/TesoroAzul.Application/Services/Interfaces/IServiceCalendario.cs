using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Application.DTOs;

namespace TesoroAzul.Application.Services.Interfaces
{
    public interface IServiceCalendario
    {
        Task<DateOnly> CalculaFechaFin(DateOnly fechaInicio, int idCrucero);
        Task<CalendarioDTO> FindByIdAsync(DateOnly fechaInicio, int idCrucero);
    }
}

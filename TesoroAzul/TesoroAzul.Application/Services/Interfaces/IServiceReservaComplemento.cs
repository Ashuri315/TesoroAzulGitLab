using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Application.DTOs;

namespace TesoroAzul.Application.Services.Interfaces
{
    public interface IServiceReservaComplemento
    {
        Task<int> CalculaTotalComplemento(ReservaComplementoDTO reservaComp);
        Task<ReservaComplementoDTO> FindByIdAsync(int idReserva, int idComplemento);
    }
}

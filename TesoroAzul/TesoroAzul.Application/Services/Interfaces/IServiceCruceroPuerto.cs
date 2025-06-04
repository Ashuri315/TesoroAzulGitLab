using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;
using TesoroAzul.Application.DTOs;

namespace TesoroAzul.Application.Services.Interfaces
{
    public interface IServiceCruceroPuerto
    {
        Task<CruceroPuertoDTO> FindPuertoSalida(int idCrucero);
        Task<CruceroPuertoDTO> FindPuertoLlegada(int idCrucero);
    }
}

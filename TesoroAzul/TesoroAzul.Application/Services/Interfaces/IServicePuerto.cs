using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Application.DTOs;

namespace TesoroAzul.Application.Services.Interfaces
{
    public interface IServicePuerto
    {
        Task<PuertoDTO> FindByIdAsync(int id);
        Task<ICollection<PuertoDTO>> FindByNameAsync(string name);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Application.DTOs;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Application.Services.Interfaces
{
    public interface IServiceCrucero
    {
        Task<ICollection<CruceroDTO>> ListAsync();
        Task<CruceroDTO> FindByIdAsync(int id);
        Task<int> AddAsync(CruceroDTO dto);

        Task<ICollection<CruceroDTO>> CruisesForHome();
        Task<ICollection<CruceroDTO>> getCrucerosDisponibles();
    }
}

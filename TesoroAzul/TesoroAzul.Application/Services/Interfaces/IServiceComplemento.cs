using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Application.DTOs;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Application.Services.Interfaces
{
    public interface IServiceComplemento
    {
        Task<ICollection<ComplementoDTO>> ListAsync();
        Task<ICollection<ComplementoDTO>> GetComplementosHabitacion();
        Task<ICollection<ComplementoDTO>> GetComplementosPasajero();
        Task<ComplementoDTO> FindByIdAsync(int id);
        Task<int> AddAsync(ComplementoDTO dto);
        Task UpdateAsync(int id, ComplementoDTO dto);
    }
}

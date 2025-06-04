using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Application.DTOs;

namespace TesoroAzul.Application.Services.Interfaces
{
    public interface IServiceHabitacion
    {
        Task<ICollection<HabitacionDTO>> ListAsync();
        Task<HabitacionDTO> FindByIdAsync(int id);
        Task<int> AddAsync(HabitacionDTO dto);
        Task UpdateAsync(int id, HabitacionDTO dto);
        Task<bool> AnyAsync(string nombre);
        Task<ICollection<HabitacionDTO>> FindByNameAsync(string nombre);
    }
}

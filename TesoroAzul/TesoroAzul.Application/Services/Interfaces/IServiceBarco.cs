using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Application.DTOs;

namespace TesoroAzul.Application.Services.Interfaces
{
    public interface IServiceBarco
    {
        Task<ICollection<BarcoDTO>> ListAsync();
        Task<BarcoDTO> FindByIdAsync(int id);
        int CalculaTotalHabitaciones(BarcoDTO barco);
        Task<int> AddAsync(BarcoDTO dto);
        Task UpdateAsync(int id, BarcoDTO dto);
        Task<bool> AnyAsync(string nombre);
        Task<ICollection<BarcoDTO>> FindByNameAsync(string nombre);
    }
}

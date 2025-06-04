using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryBarco
    {
        Task<ICollection<Barco>> ListAsync();
        Task<Barco> FindByIdAsync(int id);
        Task<int> AddAsync(Barco entity);
        Task UpdateAsync(Barco entity);
        Task<bool> AnyAsync(string nombre);
        Task<ICollection<Barco>> FindByNameAsync(string nombre);
        
    }
}

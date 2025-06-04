using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryComplemento
    {
        Task<ICollection<Complemento>> ListAsync();
        Task<ICollection<Complemento>> GetComplementosHabitacion();
        Task<ICollection<Complemento>> GetComplementosPasajero();
        Task<Complemento> FindByIdAsync(int id);
        Task<int> AddAsync(Complemento entity);
        Task UpdateAsync(Complemento entity);
    }
}

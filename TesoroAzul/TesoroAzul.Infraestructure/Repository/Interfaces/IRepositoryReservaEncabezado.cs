using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryReservaEncabezado
    {
        Task<ICollection<ReservaEncabezado>> ListAsync();
        Task<ReservaEncabezado> FindByIdAsync(int id);
        Task<int> AddAsync(ReservaEncabezado entity);
    }
}

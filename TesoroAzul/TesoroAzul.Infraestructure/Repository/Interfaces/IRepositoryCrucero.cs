using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryCrucero
    {
        Task<ICollection<Crucero>> ListAsync();
        Task<Crucero> FindByIdAsync(int id);
        Task<int> AddAsync(Crucero entity);

        Task<ICollection<Crucero>> CruisesForHome();

        Task<ICollection<Crucero>> getCrucerosDisponibles();
    }
}

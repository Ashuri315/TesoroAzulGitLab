using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryHabitacion
    {
        Task<ICollection<Habitacion>> ListAsync();
        Task<Habitacion> FindByIdAsync(int id);
        Task<int> AddAsync(Habitacion entity);
        Task UpdateAsync(Habitacion entity);
        Task <bool> AnyAsync(string nombre);
        Task<ICollection<Habitacion>> FindByNameAsync(string nombre);

        Task<ICollection<Habitacion>> GetHabitacionesDisponibles();
        //Task<ICollection<Habitacion>> GetHabitacionesByIdBarco(int idBarco);
    }
}

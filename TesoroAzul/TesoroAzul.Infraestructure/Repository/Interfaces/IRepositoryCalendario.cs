using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryCalendario
    {
        Task<Calendario> FindByIdAsync(DateOnly fechaInicio, int idCrucero);
    }
}

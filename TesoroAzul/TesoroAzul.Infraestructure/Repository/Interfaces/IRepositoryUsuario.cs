using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryUsuario
    {
        Task<Usuario> FindByIdAsync (string id);
        Task<Usuario> LoginAsync(string id, string password);
        Task<string> AddAsync(Usuario entity);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Application.DTOs;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Application.Services.Interfaces
{
    public interface IServiceCuentaCobrar
    {
        Task<int> AddAsync(CuentaCobrarDTO dto);
    }
}

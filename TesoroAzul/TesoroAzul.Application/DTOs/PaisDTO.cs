using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Application.DTOs
{
    public record PaisDTO
    {
        public int IdPais { get; set; }

        public string Nombre { get; set; } = null!;

        public virtual List<PuertoDTO> Puerto { get; set; } = new List<PuertoDTO>();
    }
}

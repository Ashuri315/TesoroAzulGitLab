using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Application.DTOs
{
    public record PuertoDTO
    {
        public int IdPuerto { get; set; }

        public int IdPais { get; set; }

        public string Nombre { get; set; } = null!;

        public virtual List<CruceroPuertoDTO> CruceroPuerto { get; set; } = new List<CruceroPuertoDTO>();

        public virtual PaisDTO IdPaisNavigation { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Application.DTOs
{
    public record CuentaCobrarDTO
    {
        public int IdReserva { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public int MontoCobrar { get; set; }

        public bool Activo { get; set; }

        public virtual ReservaEncabezadoDTO IdReservaNavigation { get; set; } = null!;
    }
}

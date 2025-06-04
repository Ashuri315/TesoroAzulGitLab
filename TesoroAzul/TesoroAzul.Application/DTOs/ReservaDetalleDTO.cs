using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Application.DTOs
{
    public record ReservaDetalleDTO
    {
        public int IdReserva { get; set; }

        public int IdReservaDetalle { get; set; }

        [Display(Name = "Habitación")]
        public int IdHabitacion { get; set; }
        public string NombreHabitacion { get; set; } = default!;

        [Display(Name = "Cantidad de huéspedes")]
        public int CantidadHuespedes { get; set; }
        [Display(Name = "Precio")]
        public int Precio { get; set; }

        public virtual List<HuespedDTO> Huesped { get; set; } = new List<HuespedDTO>();

        public virtual HabitacionDTO IdHabitacionNavigation { get; set; } = null!;

        public virtual ReservaEncabezadoDTO IdReservaNavigation { get; set; } = null!;
    }
}

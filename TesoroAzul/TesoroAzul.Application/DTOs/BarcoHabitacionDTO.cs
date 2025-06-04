using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Application.DTOs
{
    public record BarcoHabitacionDTO
    {
        public int IdBarco { get; set; }

        public int IdHabitacion { get; set; }

        public int Cantidad { get; set; }

        public virtual BarcoDTO IdBarcoNavigation { get; set; } = null!;

        public virtual HabitacionDTO IdHabitacionNavigation { get; set; } = null!;

        [Display(Name = "Habitación")]
        public string NombreHabitacion { get; set; } = default!;
    }
}

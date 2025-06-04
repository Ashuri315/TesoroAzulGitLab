using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Application.DTOs
{
    public record CalendarioHabitacionDTO
    {
        public string NombreHabitacion { get; set; }
        public int IdHabitacion { get; set; }

        public DateOnly FechaInicio { get; set; }

        public int IdCrucero { get; set; }

        public double Precio { get; set; }

        public int Disponible { get; set; }

        public virtual CalendarioDTO Calendario { get; set; } = null!;

        public virtual HabitacionDTO IdHabitacionNavigation { get; set; } = null!;
    }
}

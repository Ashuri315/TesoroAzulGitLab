using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Application.DTOs
{
    public record CalendarioDTO
    {
        //Inicio variables calculadas
        public DateOnly FechaFin { get; set; }

        //Fin variables calculadas
        [Display(Name = "Fecha de inicio")]
        public DateOnly FechaInicio { get; set; }

        public int IdCrucero { get; set; }

        [Display(Name = "Fecha límite de pago")]
        public DateOnly FechaPago { get; set; }

        public virtual List<CalendarioHabitacionDTO> CalendarioHabitacion { get; set; } = new List<CalendarioHabitacionDTO>();

        public virtual CruceroDTO IdCruceroNavigation { get; set; } = null!;

        public virtual List<ReservaEncabezadoDTO> ReservaEncabezado { get; set; } = new List<ReservaEncabezadoDTO>();
    }
}

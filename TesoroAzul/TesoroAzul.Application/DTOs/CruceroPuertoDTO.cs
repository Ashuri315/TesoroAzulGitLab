using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Application.DTOs
{
    public record CruceroPuertoDTO
    {
        //Inicio campo calculado
        [Display(Name = "Puerto")]
        public string? NombrePuerto { get; set; }

        public int CantidadDias { get; set; }
        //Fin campo calculado
        public int IdCrucero { get; set; }

        public int IdPuerto { get; set; }

        [Display(Name = "Hora de llegada")]
        public string? HoraLlegada { get; set; }

        [Display(Name = "Hora de salida")]
        public string? HoraSalida { get; set; }

        public int NumeroDia { get; set; }

        public virtual CruceroDTO IdCruceroNavigation { get; set; } = null!;

        public virtual PuertoDTO IdPuertoNavigation { get; set; } = null!;
    }
}

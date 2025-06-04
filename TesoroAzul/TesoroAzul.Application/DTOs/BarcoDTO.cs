using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TesoroAzul.Application.DTOs
{
    public record BarcoDTO
    {
        //Inicio variable calculadas
        [Display(Name = "Total de habitaciones")]
        public int totalHabitaciones {  get; set; }
        //Fin variables calculadas
        [Display(Name = "ID")]
        [ValidateNever]
        public int IdBarco { get; set; }


        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El {0} solo puede contener letras y espacios")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El {0} es requerido")]
        public string Nombre { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = " La {0} es requerida")]
        public string Descripcion { get; set; } = null!;

        public byte[] Foto { get; set; } = null!;

        [Display(Name = "Capacidad de Huéspedes")]
        [Range(1, int.MaxValue, ErrorMessage = "La capacidad de huéspedes debe ser mayor o igual a 1.")]
        [Required(ErrorMessage = "La capacidad de huéspedes es requerida")]
        public int CapacidadHuespedes { get; set; }

        public virtual List<BarcoHabitacionDTO> BarcoHabitacion { get; set; } = new List<BarcoHabitacionDTO>();

        public virtual List<CruceroDTO> Crucero { get; set; } = new List<CruceroDTO>();
    }
}

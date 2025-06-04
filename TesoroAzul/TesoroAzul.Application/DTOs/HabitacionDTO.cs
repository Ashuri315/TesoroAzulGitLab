using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Serialization;
using TesoroAzul.Application.CustomValidation;
namespace TesoroAzul.Application.DTOs
{
    public record HabitacionDTO
    {
        [Display(Name = "ID")]
        [ValidateNever]
        public int IdHabitacion { get; set; }

        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El {0} solo puede contener letras y espacios")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El {0} es requerido")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Descripción")]
        [Required(AllowEmptyStrings =false, ErrorMessage = " La {0} es requerida")]
        public string Descripcion { get; set; } = null!;

        [Display(Name = "Cantidad máxima de huéspedes")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad máxima de huéspedes debe ser mayor o igual a 1.")]
        [Required(ErrorMessage = "La cantidad máxima de huéspedes es requerida")]
        public int MaximoHuespedes { get; set; }

       
        [Display(Name = "Cantidad mínima de huéspedes")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad mínima de huéspedes debe ser mayor o igual a 1.")]
        [Required(ErrorMessage = "La cantidad mínima de huéspedes es requerida")]
        public int MinimoHuespedes { get; set; }

        [Display(Name = "Tamaño")]
        [Range(1, int.MaxValue, ErrorMessage = "El tamaño debe ser mayor o igual a 1.")]
        [Required(ErrorMessage = "La cantidad mínima de huéspedes es requerida")]
        public int Tamanio { get; set; }

        [Required(ErrorMessage = "La imagen es obligatoria.")]
        [DataType(DataType.Upload)]
        public byte[]? imagen{ get; set; }

        public virtual List<BarcoHabitacionDTO> BarcoHabitacion { get; set; } = new List<BarcoHabitacionDTO>();

        public virtual List<CalendarioHabitacionDTO> CalendarioHabitacion { get; set; } = new List<CalendarioHabitacionDTO>();

        public virtual List<ReservaDetalleDTO> ReservaDetalle { get; set; } = new List<ReservaDetalleDTO>();
    }
}

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Application.DTOs
{
    public record CruceroDTO
    {

        //Inicio variables caclculadas
        [ValidateNever]
        public CruceroPuertoDTO puertoSalida { get; set; } = null!;
        [ValidateNever]
        public CruceroPuertoDTO puertoLlegada { get; set; } = null!;

        public string? NombreBarco { get; set; }
        //Fin variables calculadas

        [Display(Name = "ID")]
        public int IdCrucero { get; set; }

        public int IdBarco { get; set; }

        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El {0} solo puede contener letras y espacios")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El {0} es requerido")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "La imagen es obligatoria.")]
        [DataType(DataType.Upload)]
        public byte[] Foto { get; set; } = null!;

        [Display(Name = "Cantidad de días")]
        [Range(2, int.MaxValue, ErrorMessage = "La cantidad de días debe ser mayor o igual a 2.")]
        [Required(ErrorMessage = "La cantidad de días es requerido")]
        public int CantidadDias { get; set; }

        public virtual List<CalendarioDTO> Calendario { get; set; } = new List<CalendarioDTO>();

        public virtual List<CruceroPuertoDTO> CruceroPuerto { get; set; } = new List<CruceroPuertoDTO>();

        [ValidateNever]
        public virtual BarcoDTO IdBarcoNavigation { get; set; } = null!;
    }
}

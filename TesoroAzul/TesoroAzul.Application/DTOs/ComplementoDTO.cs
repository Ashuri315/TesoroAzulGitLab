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
    public record ComplementoDTO
    {
        [Display(Name = "ID")]
        [ValidateNever]
        public int IdComplemento { get; set; }

        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El {0} solo puede contener letras y espacios")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El {0} es requerido")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Descripción")]
        [Required(AllowEmptyStrings = false, ErrorMessage = " La {0} es requerida")]
        public string Descripcion { get; set; } = null!;

        [Range(1000, int.MaxValue, ErrorMessage = "El precio no puede ser menor a ₡1000.")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "El precio es requerido")]
        public int Precio { get; set; }


        [Display(Name = "Precio Aplicado")]
        public string PrecioAplicado { get; set; } = null!;

        public virtual List<ReservaComplementoDTO> IdReserva { get; set; } = new List<ReservaComplementoDTO>();
    }
}

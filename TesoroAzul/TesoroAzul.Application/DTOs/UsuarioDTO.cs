using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TesoroAzul.Infraestructure.Models;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TesoroAzul.Application.DTOs
{
    public record UsuarioDTO
    {
        [Display(Name = "ID")]
        [ValidateNever]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-ZÁÉÍÓÚáéíóúÑñ\s]+$", ErrorMessage = "El nombre solo puede contener letras.")]
        [Display(Name = "Usuario")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "El correo electrónico no es válido.")]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; } = null!;


        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; } = null!;

        public string Tipo { get; set; } = null!;

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El teléfono debe tener 8 dígitos numéricos.")]
        public int Telefono { get; set; }


        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateOnly FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La nacionalidad es obligatoria.")]
        public string Nacionalidad { get; set; } = null!;

        public virtual List<ReservaEncabezadoDTO> ReservaEncabezado { get; set; } = new();
    }
}

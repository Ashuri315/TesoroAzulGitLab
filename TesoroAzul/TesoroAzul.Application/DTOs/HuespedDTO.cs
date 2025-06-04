using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Application.DTOs
{
    public record HuespedDTO
    {
        public int IdHuesped { get; set; }

        public int IdReserva { get; set; }

        public int IdReservaDetalle { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Email { get; set; }

        public DateOnly FechaNacimiento { get; set; }
        public int? Telefono { get; set; }

        public string Genero { get; set; } = null!;

        public virtual ReservaDetalle ReservaDetalle { get; set; } = null!;
    }
}

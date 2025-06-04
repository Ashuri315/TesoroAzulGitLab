using System;
using System.Collections.Generic;

namespace TesoroAzul.Infraestructure.Models;

public partial class Huesped
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

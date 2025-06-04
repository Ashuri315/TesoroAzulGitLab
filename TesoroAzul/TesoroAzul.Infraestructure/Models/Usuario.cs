using System;
using System.Collections.Generic;

namespace TesoroAzul.Infraestructure.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public int Telefono { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public string Nacionalidad { get; set; } = null!;

    public virtual ICollection<ReservaEncabezado> ReservaEncabezado { get; set; } = new List<ReservaEncabezado>();
}

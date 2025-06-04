using System;
using System.Collections.Generic;

namespace TesoroAzul.Infraestructure.Models;

public partial class CuentaCobrar
{
    public int IdReserva { get; set; }

    public int MontoCobrar { get; set; }

    public bool Activo { get; set; }

    public virtual ReservaEncabezado IdReservaNavigation { get; set; } = null!;
}

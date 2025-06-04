using System;
using System.Collections.Generic;

namespace TesoroAzul.Infraestructure.Models;

public partial class ReservaComplemento
{
    public int IdReserva { get; set; }

    public int IdComplemento { get; set; }

    public int Cantidad { get; set; }

    public virtual Complemento IdComplementoNavigation { get; set; } = null!;

    public virtual ReservaEncabezado IdReservaNavigation { get; set; } = null!;
}

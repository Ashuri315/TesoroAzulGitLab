using System;
using System.Collections.Generic;

namespace TesoroAzul.Infraestructure.Models;

public partial class CruceroPuerto
{
    public int IdCrucero { get; set; }

    public int IdPuerto { get; set; }

    public int NumeroDia { get; set; }

    public string? HoraLlegada { get; set; }

    public string? HoraSalida { get; set; }

    public virtual Crucero IdCruceroNavigation { get; set; } = null!;

    public virtual Puerto IdPuertoNavigation { get; set; } = null!;
}

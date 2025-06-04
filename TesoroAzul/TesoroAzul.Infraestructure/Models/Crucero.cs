using System;
using System.Collections.Generic;

namespace TesoroAzul.Infraestructure.Models;

public partial class Crucero
{
    public int IdCrucero { get; set; }

    public int IdBarco { get; set; }

    public string Nombre { get; set; } = null!;

    public byte[]? Foto { get; set; }

    public int CantidadDias { get; set; }

    public virtual ICollection<Calendario> Calendario { get; set; } = new List<Calendario>();

    public virtual ICollection<CruceroPuerto> CruceroPuerto { get; set; } = new List<CruceroPuerto>();

    public virtual Barco IdBarcoNavigation { get; set; } = null!;
}

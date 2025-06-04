using System;
using System.Collections.Generic;

namespace TesoroAzul.Infraestructure.Models;

public partial class Puerto
{
    public int IdPuerto { get; set; }

    public int IdPais { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<CruceroPuerto> CruceroPuerto { get; set; } = new List<CruceroPuerto>();

    public virtual Pais IdPaisNavigation { get; set; } = null!;
}

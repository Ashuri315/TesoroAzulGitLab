using System;
using System.Collections.Generic;

namespace TesoroAzul.Infraestructure.Models;

public partial class Pais
{
    public int IdPais { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Puerto> Puerto { get; set; } = new List<Puerto>();
}

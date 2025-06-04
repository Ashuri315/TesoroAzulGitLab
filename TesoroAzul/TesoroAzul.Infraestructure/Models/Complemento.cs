using System;
using System.Collections.Generic;

namespace TesoroAzul.Infraestructure.Models;

public partial class Complemento
{
    public int IdComplemento { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int Precio { get; set; }

    public string PrecioAplicado { get; set; } = null!;

    public virtual ICollection<ReservaComplemento> ReservaComplemento { get; set; } = new List<ReservaComplemento>();
}

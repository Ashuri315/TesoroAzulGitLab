using System;
using System.Collections.Generic;

namespace TesoroAzul.Infraestructure.Models;

public partial class ReservaDetalle
{
    public int IdReserva { get; set; }

    public int IdReservaDetalle { get; set; }

    public int IdHabitacion { get; set; }

    public int CantidadHuespedes { get; set; }

    public virtual ICollection<Huesped> Huesped { get; set; } = new List<Huesped>();

    public virtual Habitacion IdHabitacionNavigation { get; set; } = null!;

    public virtual ReservaEncabezado IdReservaNavigation { get; set; } = null!;
}

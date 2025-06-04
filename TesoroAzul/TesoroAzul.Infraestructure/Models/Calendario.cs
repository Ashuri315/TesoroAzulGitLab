using System;
using System.Collections.Generic;

namespace TesoroAzul.Infraestructure.Models;

public partial class Calendario
{
    public DateOnly FechaInicio { get; set; }

    public int IdCrucero { get; set; }

    public DateOnly FechaPago { get; set; }

    public virtual ICollection<CalendarioHabitacion> CalendarioHabitacion { get; set; } = new List<CalendarioHabitacion>();

    public virtual Crucero IdCruceroNavigation { get; set; } = null!;

    public virtual ICollection<ReservaEncabezado> ReservaEncabezado { get; set; } = new List<ReservaEncabezado>();
}

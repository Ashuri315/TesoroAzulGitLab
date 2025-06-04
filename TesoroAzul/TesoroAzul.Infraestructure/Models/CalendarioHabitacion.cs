using System;
using System.Collections.Generic;

namespace TesoroAzul.Infraestructure.Models;

public partial class CalendarioHabitacion
{
    public int IdHabitacion { get; set; }

    public DateOnly FechaInicio { get; set; }

    public int IdCrucero { get; set; }

    public double Precio { get; set; }

    public int Disponible { get; set; }

    public virtual Calendario Calendario { get; set; } = null!;

    public virtual Habitacion IdHabitacionNavigation { get; set; } = null!;
}

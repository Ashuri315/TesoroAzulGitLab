using System;
using System.Collections.Generic;

namespace TesoroAzul.Infraestructure.Models;

public partial class Habitacion
{
    public int IdHabitacion { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int MaximoHuespedes { get; set; }

    public int MinimoHuespedes { get; set; }

    public int Tamanio { get; set; }

    public byte[]? Imagen { get; set; }

    public virtual ICollection<BarcoHabitacion> BarcoHabitacion { get; set; } = new List<BarcoHabitacion>();

    public virtual ICollection<CalendarioHabitacion> CalendarioHabitacion { get; set; } = new List<CalendarioHabitacion>();

    public virtual ICollection<ReservaDetalle> ReservaDetalle { get; set; } = new List<ReservaDetalle>();
}

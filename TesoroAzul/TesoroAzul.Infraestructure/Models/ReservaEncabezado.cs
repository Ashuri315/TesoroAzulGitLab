using System;
using System.Collections.Generic;

namespace TesoroAzul.Infraestructure.Models;

public partial class ReservaEncabezado
{
    public int IdReserva { get; set; }

    public DateOnly Fecha { get; set; }

    public DateOnly FechaInicio { get; set; }

    public int IdCrucero { get; set; }

    public int IdUsuario { get; set; }

    public int CantidadHabitaciones { get; set; }

    public int CantidadPasajeros { get; set; }

    public int TotalHabitaciones { get; set; }

    public int TotalComplementos { get; set; }

    public int Subtotal { get; set; }

    public int Impuestos { get; set; }

    public int Total { get; set; }

    public bool Pendiente { get; set; }

    public virtual Calendario Calendario { get; set; } = null!;

    public virtual CuentaCobrar? CuentaCobrar { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<ReservaComplemento> ReservaComplemento { get; set; } = new List<ReservaComplemento>();

    public virtual ICollection<ReservaDetalle> ReservaDetalle { get; set; } = new List<ReservaDetalle>();
}

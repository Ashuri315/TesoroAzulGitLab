using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Application.DTOs
{
    public record ReservaEncabezadoDTO
    {
        //Variables para calculos y metodos
        public string estado_pago { get; set; } = null!;
        public string logobase64 { get; set; }
        //Fin variables para calculos y metodos


        [Display(Name = "No. Reserva")]
        [ValidateNever]
        public int IdReserva { get; set; }

        public DateOnly Fecha { get; set; }

        [Display(Name = "Fecha de Inicio")]
        public DateOnly FechaInicio { get; set; }

        public int IdCrucero { get; set; }

        [Display(Name = "Usuario asociado a la reserva")]
        public int IdUsuario { get; set; }

        public int CantidadHabitaciones { get; set; }

        public int CantidadPasajeros { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public int TotalHabitaciones { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public int TotalComplementos { get; set; }

        public string? NombreCrucero { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public int Subtotal { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public int Impuestos { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public int Total { get; set; }

        public bool Pendiente { get; set; }

        public virtual CalendarioDTO Calendario { get; set; } = null!;

        public virtual CuentaCobrarDTO CuentaCobrar { get; set; } = null!;

        public virtual UsuarioDTO IdUsuarioNavigation { get; set; } = null!;

        public virtual List<ReservaDetalleDTO> ReservaDetalle { get; set; } = new List<ReservaDetalleDTO>();

        public virtual List<ReservaComplementoDTO> ReservaComplemento { get; set; } = new List<ReservaComplementoDTO>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Application.DTOs
{
    public record ReservaComplementoDTO
    {
        //Inicio variables calculadas
        public int TotalComp {  get; set; }
        //Fin variables calculadas
        public int IdReserva { get; set; }

        public int IdComplemento { get; set; }

        public int Cantidad { get; set; }

        public string NombreComplemento { get; set; } = default!;
        public string Aplicacion { get; set; } = default!;
        public virtual ComplementoDTO IdComplementoNavigation { get; set; } = null!;

        public virtual ReservaEncabezadoDTO IdReservaNavigation { get; set; } = null!;
    }
}

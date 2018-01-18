using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models.entities
{
    public class OperacionCliente
    {
        public int? Operacion { get; set; }
        public string Glosa { get; set; }
        public DateTime? FechaOper { get; set; }
        public decimal? Tasa { get; set; }
        public int? TotalDoc { get; set; }
        public decimal? ValRemesa { get; set; }
        public decimal? MontoCheq { get; set; }

        
    }
}
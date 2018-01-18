using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models.entities
{
    public class SaldosCliente
    {
        public double? MontoLinea { get; set; }
        public double? SaldoLinea { get; set; }
        public double? Vigente { get; set; }
        public int? Moroso { get; set; }
        public int? Historico { get; set; }
        public string  Fecha { get; set; }
        public double? Excedentes { get; set; }
       
    }
}
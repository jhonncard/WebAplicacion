using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models.entities
{
    public class DeudoresOperacion
    {
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public int NroDocumento { get; set; }
        public DateTime? FechaV { get; set; }
        public int? Plaza { get; set; }
        public string DiasDiff { get; set; }
        public decimal? Monto1 { get; set; }
        public decimal? Monto2 { get; set; }
        public decimal? Monto3 { get; set; }
        public string VctoLinea { get; set; }
        public decimal? SaldoLinea { get; set; }
        public int? Plazo { get; set; }
        public string Protesto { get; set; }
        public string AdvLinea { get; set; }
        public string Reempl { get; set; }
        public string Actividad { get; set; }
    }
}
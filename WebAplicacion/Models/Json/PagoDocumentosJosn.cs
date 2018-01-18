using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models.Json
{
    public class PagoDocumentosJosn
    {

        public int? Operacion { get; set; }
        public decimal? MontoC { get; set; }
        public int? Correlativo { get; set; }
        public decimal? Mora { get; set; }
        public int? Devolucion { get; set; }
        public decimal? Liquido { get; set; }
        public decimal? GastosProt { get; set; }
        public int? IntProrro { get; set; }
        public string RutCliente { get; set; }
    
    }
}
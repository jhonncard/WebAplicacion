using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models.Json
{
    public class ActualizarDecuentoJson
    {
        public string RutCliente { get; set; }
        public string Fecha { get; set; }
        public int? Cesion { get; set; }
        public decimal? Monto { get; set; }

    }
}
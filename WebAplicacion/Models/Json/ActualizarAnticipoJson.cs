using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models.Json
{
    public class ActualizarAnticipoJson
    {
        public string RutCliente { get; set; }

        public int? NroAnticipo { get; set; }
        public string Estado { get; set; }
        public int? Cesion { get; set; }


       
    }
}
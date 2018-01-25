using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models.Json
{
    public class VIngresoSimulacion
    {
        public string RutCliente { get; set; }
        public string RutDeudor { get; set; }
        public string Nombre { get; set; }
        public int CodPais { get; set; }
        public int CodCiudad { get; set; }
        public ulong NroDcto { get; set; }
        public int TipoDcto { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models.Json
{
    public class DocumentoRelacionJson
    {

        public string RutCliente { get; set; }
        public string NroOperRemesa { get; set; }
        public string CodTipoOperacion { get; set; }
        public string CodCobranza { get; set; }
        public string 	CodResponsabilidad { get; set; }
        public string CodSeguro { get; set; }
        public int? Flag { get; set; }
      
    }
}
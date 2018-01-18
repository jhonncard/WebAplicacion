using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models.entities
{
    public class DocumentosContratados
    {

        public string RutDeudor { get; set; }
        public string Nombre { get; set; }
        public int? Ndocto { get; set; }
        public string GlosaDocto { get; set; }
        public string GlosaMoneda { get; set; }
        public decimal? Monto { get; set; }
        public DateTime? FechaV { get; set; }
        public int? Tipodocto { get; set; }

        
    }
}
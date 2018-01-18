using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models.Json
{
    public class Finaciero
    {
     
        public decimal? Comision { get; set; }
        public decimal? ComisionMin { get; set; }
        public decimal? ComisionMax { get; set; }
        public decimal? Tasa { get; set; }
        public decimal? Anticipo { get; set; }
        public decimal? GastoOper { get; set; }
        public int? PlazoMin { get; set; }
        public int ? PlazoMax { get; set; }
        public int? DiasLinea { get; set; }
        public decimal? PlazoEmision { get; set; }
        public decimal? Notificacion { get; set; }
        public decimal? NotificacionDocto { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models.entities
{
    public class DatosClientes
    {
        public int? notificacion { get; set; }
        public string Rut { get; set; }
        public string Actividad { get; set; }
        public string Nombre { get; set; }
        public int? Comision { get; set; }
        public int? MontoMin { get; set; }
        public int? MontoMax { get; set; }
        public decimal? Tasa { get; set; }
        public int? Financiamiento { get; set; }
        public int? Notificacion { get; set; }
        public decimal? GastoOper { get; set; }
        public string Glosa { get; set; }
        public int? MedioPago { get; set; }
         
    }
}
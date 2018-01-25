using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models.Json.Grabar
{
    public class DetalleDocJason
    {
        public int? Operacion { get; set; }
        public int? Contrato { get; set; }
        public int? Correlativo { get; set; }
        public string RutDeudor { get; set; }
        public string RutCliente { get; set; }
        public int? Actividad { get; set; }
        public int? TipoDocto { get; set; }
        public decimal? Monto { get; set; }
        public decimal? MontoMoneda { get; set; }
        public string FechaE { get; set; }
        public string FechaV { get; set; }
        public string FechaL { get; set; }
        public int? plaza { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public decimal? SaldoDoc { get; set; }
        public int? MonedaDoc { get; set; }
        public string DocJunto { get; set; }
        public string EstadoAct { get; set; }
        public int? TipoOpera { get; set; }
        public int? Ncontrato { get; set; }
        public string Cuenta { get; set; }
        public int? Remp { get; set; }
        public string Curse { get; set; }
        public string NdoctoE { get; set; }
        public int? Banco { get; set; }
        public decimal? Anticipo { get; set; }
        public decimal? MontoI { get; set; }
        public decimal? MontoC { get; set; }
        public decimal? MontoIVA { get; set; }
        public string Remesada { get; set; }
        public string FechaPag { get; set; }
        public string FechaReemp { get; set; }
        public int? Correlativo2 { get; set; }
        public int? NumReempl { get; set; }
        public decimal? Gastos { get; set; }
        public string  RePlazo { get; set; }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models
{
    public class CondicionescomercialesJson
    {
        public decimal factoringPymes { get; set; }
        public decimal factoringMedianas { get; set; }
        public decimal factoringGrandes { get; set; }
        public decimal factoringCoorporativas { get; set; }
        public decimal factoringInmobiliarias { get; set; }
        public decimal confirmingPymes { get; set; }
        public decimal confirmingMedianas { get; set; }
        public decimal confirmingGrandes { get; set; }
        public decimal confirmingCoorporativas { get; set; }
        public decimal confirmingInmobiliarias { get; set; }
        public decimal cobranzaDelegadaPymes { get; set; }
        public decimal cobranzaDelegadaMedianas { get; set; }
        public decimal cobranzaDelegadaGrandes { get; set; }
        public decimal cobranzaDelegadaCoorporativas { get; set; }
        public decimal cobranzaDelegadaInmobiliarias { get; set; }
        public decimal tasaSpreadBolsaProductos { get; set; }
        public decimal comisionPyme { get; set; }
        public decimal comisionBancaEmpresa { get; set; }
        public string  comisionTipoMoneda { get; set; }
        public decimal gastosNotariaDeudor { get; set; }
        public decimal gastosNotariaNFacturas { get; set; }
        public string gastosTipoMoneda { get; set; }
 
    }
}
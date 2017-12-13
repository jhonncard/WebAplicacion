using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models
{
    public class CondicionescomercialesJson
    {
        public float factoringPymes { get; set; }
        public float factoringMedianas { get; set; }
        public float factoringGrandes { get; set; }
        public float factoringCoorporativas { get; set; }
        public float factoringInmobiliarias { get; set; }
        public float confirmingPymes { get; set; }
        public float confirmingMedianas { get; set; }
        public float confirmingGrandes { get; set; }
        public float confirmingCoorporativas { get; set; }
        public float confirmingInmobiliarias { get; set; }
        public float cobranzaDelegadaPymes { get; set; }
        public float cobranzaDelegadaMedianas { get; set; }
        public float cobranzaDelegadaGrandes { get; set; }
        public float cobranzaDelegadaCoorporativas { get; set; }
        public float cobranzaDelegadaInmobiliarias { get; set; }
        public float tasaSpreadBolsaProductos { get; set; }
        public float comisionPyme { get; set; }
        public float comisionBancaEmpresa { get; set; }
        public string  comisionTipoMoneda { get; set; }
        public float gastosNotariaDeudor { get; set; }
        public float gastosNotariaNFacturas { get; set; }
        public string gastosTipoMoneda { get; set; }
 
    }
}
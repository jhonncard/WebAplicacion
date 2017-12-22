using System;


namespace Factoring.Negocios.util
{
    class CondicionesDto
    {
      
        public int id { get; set; }

        /* FACTURING */      
        public Nullable<decimal> FactoringPymes { get; set; }

        public Nullable<decimal> FactoringMedianas { get; set; }

        public Nullable<decimal> FactoringGrandes { get; set; }

        public Nullable<decimal> FactoringCoorporativas { get; set; }

        public Nullable<decimal> FactoringInmobiliarias { get; set; }

        /* CONFIRMING */
        public Nullable<decimal> ConfirmingPymes { get; set; }

        public Nullable<decimal> ConfirmingMedianas { get; set; }

        public Nullable<decimal> ConfirmingGrandes { get; set; }

        public Nullable<decimal> ConfirmingCoorporativas { get; set; }

        public Nullable<decimal> ConfirmingInmobiliarias { get; set; }

        /* COMBRANZA DELEGADA  */
        public Nullable<decimal> CobranzaDelegadaPymes { get; set; }

        public Nullable<decimal> CobranzaDelegadaMedianas { get; set; }

        public Nullable<decimal> CobranzaDelegadaGrandes { get; set; }

        public Nullable<decimal> CobranzaDelegadaCoorporativas { get; set; }

        public Nullable<decimal> CobranzaDelegadaInmobiliarias { get; set; }


        public Nullable<decimal> TasaSpreadBolsaProductos { get; set; }

        public Nullable<decimal> ComisionPyme { get; set; }

        public Nullable<decimal> ComisionBancaEmpresa { get; set; }

        public virtual string ComisionTipoMoneda { get; set; }

        public Nullable<decimal> GastosNotariaDeudor { get; set; }

        public Nullable<decimal> GastosNotariaNFacturas { get; set; }

        public virtual string GastosTipoMoneda { get; set; }

    }
}

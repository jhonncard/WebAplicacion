using System;


namespace Factoring.Negocios.util
{
    class CondicionesDto
    {
      
        public int id { get; set; }

        /* FACTURING */      
        public Nullable<float> FactoringPymes { get; set; }

        public Nullable<float> FactoringMedianas { get; set; }

        public Nullable<float> FactoringGrandes { get; set; }

        public Nullable<float> FactoringCoorporativas { get; set; }

        public Nullable<float> FactoringInmobiliarias { get; set; }

        /* CONFIRMING */
        public Nullable<float> ConfirmingPymes { get; set; }

        public Nullable<float> ConfirmingMedianas { get; set; }

        public Nullable<float> ConfirmingGrandes { get; set; }

        public Nullable<float> ConfirmingCoorporativas { get; set; }

        public Nullable<float> ConfirmingInmobiliarias { get; set; }

        /* COMBRANZA DELEGADA  */
        public Nullable<float> CobranzaDelegadaPymes { get; set; }

        public Nullable<float> CobranzaDelegadaMedianas { get; set; }

        public Nullable<float> CobranzaDelegadaGrandes { get; set; }

        public Nullable<float> CobranzaDelegadaCoorporativas { get; set; }

        public Nullable<float> CobranzaDelegadaInmobiliarias { get; set; }


        public Nullable<float> TasaSpreadBolsaProductos { get; set; }

        public Nullable<float> ComisionPyme { get; set; }

        public Nullable<float> ComisionBancaEmpresa { get; set; }

        public virtual string ComisionTipoMoneda { get; set; }

        public Nullable<float> GastosNotariaDeudor { get; set; }

        public Nullable<float> GastosNotariaNFacturas { get; set; }

        public virtual string GastosTipoMoneda { get; set; }

    }
}

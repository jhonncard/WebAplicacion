using System;


namespace Factoring.Negocios.util
{
    class DeudorDto
    {
        
        public int Rut { set; get; }
               
        public string Cliente { set; get; }
                
        public bool Bloqueo { get; set; }          

        public int? Dias { get; set; }

        public bool Sinacofi { get; set; }

        public decimal? Aprobado { get; set; }

        public decimal? Utilizado { get; set; }

        public decimal? pago12 { get; set; }

        public decimal? pago6 { get; set; }

        public decimal? Mora12 { get; set; }

        public decimal? Mora6 { get; set; }
        
        public decimal? NroDoc12 { get; set; }
        
        public decimal? NroDoc6 { get; set; }
        
        public string Clasificacion { get; set; }

         public string tipoDeudor { get; set; }
    }
}

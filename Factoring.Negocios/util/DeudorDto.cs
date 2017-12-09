using System;


namespace Factoring.Negocios.util
{
    class DeudorDto
    {
        
        public int Rut { set; get; }
               
        public string Cliente { set; get; }
                
        public bool Bloqueo { get; set; }          

        public Nullable<int> Dias { get; set; }

        public bool Sinacofi { get; set; }

        public Nullable<float> Aprobado { get; set; }

        public Nullable<float> Utilizado { get; set; }

        public Nullable<float> pago12 { get; set; }

        public Nullable<float> pago6 { get; set; }

        public Nullable<float> Mora12 { get; set; }

        public Nullable<float> Mora6 { get; set; }
        
        public Nullable<float> NroDoc12 { get; set; }
        
        public Nullable<float> NroDoc6 { get; set; }
        
        public string Clasificacion { get; set; }

         public string tipoDeudor { get; set; }
    }
}

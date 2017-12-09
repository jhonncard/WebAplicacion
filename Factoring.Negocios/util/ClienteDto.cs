using System;


namespace Factoring.Negocios.util
{
    class ClienteDto
    {
      
        public int ID { get; set; }
             
        public string Rut { get; set; }

        public string Cliente { get; set; }
               
        public bool Bloqueo { get; set; }
               
        public Nullable<int> Desde { get; set; }
               
        public Nullable<int> Hasta { get; set; }
              
        public Nullable<float> Retencion { get; set; }
              
        public string Clasificacion { get; set; }
    }
}

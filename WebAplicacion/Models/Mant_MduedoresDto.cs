

namespace WebAplicacion.Models
{
    public class Mant_MduedoresDto
    {

       
        public string  Rut { set; get; }

        public string Cliente { set; get; }

        public int? Bloqueo { get; set; }

        public int? Sinacofi { get; set; }

        public int? Dias { get; set; }

        public string TipoDeudor { get; set; }

        public string Clasificacion { get; set; }

        public float? Aprobado { get; set; }
            
        public float? Utilizado { get; set; }
    
        public float? pago12 { get; set; }
        
        public float? pago6 { get; set; }

        public float? Mora12 { get; set; }

        public float? Mora6 { get; set; }

        public float? NroDoc12 { get; set; }

       public float? NroDoc6 { get; set; }

        
    }
}
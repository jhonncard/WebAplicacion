

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

        public decimal? Aprobado { get; set; }
            
        public decimal? Utilizado { get; set; }
    
        public decimal? pago12 { get; set; }
        
        public decimal? pago6 { get; set; }

        public decimal? Mora12 { get; set; }

        public decimal? Mora6 { get; set; }

        public decimal? NroDoc12 { get; set; }

       public decimal? NroDoc6 { get; set; }

        
    }
}
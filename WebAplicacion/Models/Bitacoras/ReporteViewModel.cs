
using System.ComponentModel.DataAnnotations;


namespace WebAplicacion.Models
{
    public class ReporteViewModel
    {
        public bool Clientes { get; set; }
        public bool Deudores { get; set; }
        
        [Display(Name="Condiciones Comerciales")]
        public bool Condiciones  { get; set; }

    }
}
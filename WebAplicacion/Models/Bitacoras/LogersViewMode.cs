
using System.ComponentModel.DataAnnotations;


namespace WebAplicacion.Models.Bitacoras
{
    public class LogersViewModel
    {
        [Display ]
        public string usuario { get; set; }

        [Display]
        public string descipcion { get; set; }
        
        public string relacion { get; set; }

        
    }
}
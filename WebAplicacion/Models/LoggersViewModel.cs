using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models
{
    public class LoggersViewModel
    {
        [Key]
        public int id { get; set; }

        [Required (ErrorMessage = "Campo Obligatorio")]
        public DateTime fecha { get; set; }

        public String  detallles  { get; set; }
        [Display ]
        public String  Usuario { get; set; }

        public String  Relacionada { get; set; }









    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models
{
    public class LoggersViewModel
    {
        [Display]
        public int Id { get; set; }

        public string  fecha { get; set; }
  
        public String  Descripcion  { get; set; }

        public String  Usuario { get; set; }

        public String  Relacionada { get; set; }

        
    }
}
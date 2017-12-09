using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models
{
    public class LogersViewModel
    {

        [Display]
        public int Id { get; set; }

        public   DateTime   fecha { get; set; }
  
        public String  Descripcion  { get; set; }

        [Display ]
        public String  Usuario { get; set; }

        public String  Relacionada { get; set; }

        
    }
}
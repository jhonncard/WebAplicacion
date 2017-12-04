using System;
using System.ComponentModel.DataAnnotations;

namespace WebAplicacion.Models
{
    public class ClasificacionViewModel
    {
        [Key]
        public Nullable<int> id { get; set; }

        [Display(Name = "clasificacion") ]
        public char Glosa { get; set; }
    }
}

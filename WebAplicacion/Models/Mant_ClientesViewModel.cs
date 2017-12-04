using System;
using System.ComponentModel.DataAnnotations;

namespace WebAplicacion.Models
{
    public class Mant_ClientesViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required( ErrorMessage = "Valor Requerido")]
        public string Rut { get; set; }

        [Required(ErrorMessage = "Valor Requerido")]
        [Range(0, 1, ErrorMessage = "Valor fuera de Rango")]
        public string Cliente { get; set; }

        [Required(ErrorMessage = "Valor Requerido")]
       // [Range(0, 1, ErrorMessage = "Valor fuera de Rango")]
        public bool Bloqueo { get; set; }

        [Required(ErrorMessage = "Valor Requerido")]
        [Display(Name = " Desde")]
        [Range(0, 1000, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<int> Desde { get; set; }

        [Required(ErrorMessage = "Valor Requerido")]
        [Display(Name = " Hasta")]
        [Range(0, 1000, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<int> Hasta { get; set; }

        [Required(ErrorMessage = "Valor Requerido")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> Retencion { get; set; }

        [Required(ErrorMessage = "Valor Requerido")]
        [Display(Name = "Clasificcacion")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public string  Clasificacion { get; set; }

    }
}
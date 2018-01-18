using System;
using System.ComponentModel.DataAnnotations;

namespace WebAplicacion.Models.Clientes
{
    public class MantClientesViewModel
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
        public int? Desde { get; set; }

        [Required(ErrorMessage = "Valor Requerido")]
        [Display(Name = " Hasta")]
        [Range(0, 1000, ErrorMessage = "Valor fuera de Rango")]
        public int? Hasta { get; set; }

        [Required(ErrorMessage = "Valor Requerido")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public decimal? Retencion { get; set; }

        [Required(ErrorMessage = "Valor Requerido")]
        [Display(Name = "Clasificcacion")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public string  Clasificacion { get; set; }

        [Required(ErrorMessage = "Valor Requerido")]
        [Display(Name = "Validacion Deudor")]
        public int? IdValidacion { get; set; }

        [Required(ErrorMessage = "Valor Requerido")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        [Display(Name = "Limite Tipo A")]
        public decimal? LimiteTipoA { get; set; }

        
        [Required(ErrorMessage = "Valor Requerido")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        [Display(Name = "Limite Tipo B")]
        public decimal? LimiteTipoB { get; set; }

        [Required(ErrorMessage = "Valor Requerido")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        [Display(Name = "Limite Tipo C")]
        public decimal? LimiteTipoC { get; set; }

        [Required(ErrorMessage = "Valor Requerido")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        [Display(Name = "Limite Tipo D")]
        public decimal? LimiteTipoD { get; set; }

        [Required(ErrorMessage = "Valor Requerido")]
        [Display(Name = "Rut Cliente")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public string RutParticular { get; set; }

        [Required(ErrorMessage = "Valor Requerido")]
        [Display(Name = "Rut Cliente")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public string Nombredeudor { get; set; }

        [Required(ErrorMessage = "Valor Requerido")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        [Display(Name = "Limite Particular")]
        public decimal? LimiteParticular { get; set; }
  

    }
}
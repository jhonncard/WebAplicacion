
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAplicacion.Models

{
    public class Mant_DuedoresViewModel
    {
        [Key]
        public string Rut { set;  get; }

        [Required]
        public string Cliente { set; get; }

        [Required]
        //[Range(0, 1, ErrorMessage = "Valor fuera de Rango")]
        public bool Bloqueo { get; set; }

        [Required]
        [Display(Name = "Días")]
        public int? Dias { get; set; }

        [Required]
        [Display(Name = "Sinacofi")]
        [DefaultValue(true)]
        public bool Sinacofi { get; set; }

        [Required]
        [Display(Name = "Maxima_Expo Aprob.")]
        public decimal? Aprobado  { get; set; }

        [Required]
        [Display(Name = "Util.")]
        public decimal? Utilizado { get; set; }

        [Required]
        [Display(Name = "Pagado en ult. 12 Meses")]
        public decimal? pago12 { get; set; }

        [Required]
        [Display(Name = "Pagado en ult. 6 Meses")]
        public decimal? pago6 { get; set; }

        [Required]
        [Display(Name = "Mora en ult. 12 Meses")]
        public decimal? Mora12 { get; set; }

        [Required]
        [Display(Name = "Mora en ult. 6 Meses")]
        public decimal? Mora6 { get; set; }

        [Required]
        [Display(Name = "Nro Doc. Pag. 12 Meses")]
        public decimal? NroDoc12 { get; set; }

        [Required]
        [Display(Name = "Nro Doc. Pag. 6 Meses")]
        public decimal? NroDoc6 { get; set; }



        [Required]
        //[Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public string Clasificacion { get; set; }

        [Required]
        [Display(Name = "Tipo deudor ")]
        //[Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public string tipoDeudor { get; set; }
    }
}


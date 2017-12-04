
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAplicacion.Models

{
    public class Mant_DuedoresViewModel
    {
        [Key]
        public int Rut { set;  get; }

        [Required]
        public string Cliente { set; get; }

        [Required]
        //[Range(0, 1, ErrorMessage = "Valor fuera de Rango")]
        public bool Bloqueo { get; set; }

        [Required]
        [Display(Name = "Días")]
        public Nullable<int> Dias { get; set; }

        [Required]
        [Display(Name = "Sinacofi")]
        [DefaultValue(true)]
        public bool Sinacofi { get; set; }

        [Required]
        [Display(Name = "Maxima_Expo Aprob.")]
        public Nullable<float> Aprobado  { get; set; }

        [Required]
        [Display(Name = "Util.")]
        public Nullable<float> Utilizado { get; set; }

        [Required]
        [Display(Name = "Pagado en ult. 12 Meses")]
        public Nullable<float> pago12 { get; set; }

        [Required]
        [Display(Name = "Pagado en ult. 6 Meses")]
        public Nullable<float> pago6 { get; set; }

        [Required]
        [Display(Name = "Mora en ult. 12 Meses")]
        public Nullable<float> Mora12 { get; set; }

        [Required]
        [Display(Name = "Mora en ult. 6 Meses")]
        public Nullable<float> Mora6 { get; set; }

        [Required]
        [Display(Name = "Nro Doc. Pag. 12 Meses")]
        public Nullable<float> NroDoc12 { get; set; }

        [Required]
        [Display(Name = "Nro Doc. Pag. 6 Meses")]
        public Nullable<float> NroDoc6 { get; set; }



        [Required]
        //[Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public string Clasificacion { get; set; }

        [Required]
        [Display(Name = "Tipo deudor ")]
        //[Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public string tipoDeudor { get; set; }
    }
}


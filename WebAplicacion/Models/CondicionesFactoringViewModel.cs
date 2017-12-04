using System;
using System.ComponentModel.DataAnnotations;

namespace WebAplicacion.Models
{
    public class CondicionesFactoringViewModel
    {
        [Key]
        public int id { get; set; }
        /* FACTURING */
        [Required]
        [Display(Name = "Empresas Pyme") ]
        [Range (0,100,ErrorMessage ="Valor fuera de Rango")]
        public Nullable<float> FactoringPyme  { get; set; }

        [Required]
        [Display(Name = "Empresas Medianas")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> FactoringMedianas { get; set; }

        [Required]
        [Display(Name = "Empresas Grandes")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> FactoringGrandes { get; set; }

        [Required]
        [Display(Name = "Empresas Coorporativas")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> FactoringCoorporativas { get; set; }

        [Required]
        [Display(Name = "Empresas Inmobiliarias")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> FactoringInmobiliarias { get; set; }

        /* CONFIRMING */
        [Required]
        [Display(Name = "Empresas Pyme")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> ConfirmingPyme { get; set; }

        [Required]
        [Display(Name = "Empresas Medianas")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> ConfirmingMedianas { get; set; }

        [Required]
        [Display(Name = "Empresas Grandes")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> ConfirmingGrandes { get; set; }

        [Required]
        [Display(Name = "Empresas Coorporativas")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> ConfirmingCoorporativas { get; set; }

        [Required]
        [Display(Name = "Empresas Inmobiliarias")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> ConfirmingInmobiliarias { get; set; }

        /* COMBRANZA DELEGADA  */
        [Required]
        [Display(Name = "Empresas Pyme")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> CobranzaDelegadaPyme { get; set; }

        [Required]
        [Display(Name = "Empresas Medianas")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> CobranzaDelegadaMedianas { get; set; }

        [Required]
        [Display(Name = "Empresas Grandes")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> CobranzaDelegadaGrandes { get; set; }

        [Required]
        [Display(Name = "Empresas Coorporativas")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> CobranzaDelegadaCoorporativas { get; set; }

        [Required]
        [Display(Name = "Empresas Inmobiliarias")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> CobranzaDelegadaInmobiliarias { get; set; }

        
        [Required]
        [Display(Name = "Bolsa de productos")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> BolsaProductos { get; set; }

            
        [Required]
        [Display(Name = "Pyme")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> Comision_pyme { get; set; }
        
        [Required]
        [Display(Name = "Banca Empresa")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> Comision_BancaEmpresa { get; set; }
        
        [Required]
        [Display(Name = "Tipo Moneda")]
        public virtual string Comision_TipoMoneda { get; set; }
        
        [Required]
        [Display(Name = "Notaría Deudor")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> Gastos_NotaríaDeudor { get; set; }

        [Required]
        [Display(Name = "Notaría N° Facturas")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> Gastos_Notaría_N_Facturas { get; set; }

        [Required]
        [Display(Name = "Tipo Moneda")]
        public virtual string Gastos_TipoMoneda { get; set; }
        

    }
}
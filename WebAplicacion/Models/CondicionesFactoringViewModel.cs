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
        [Display(Name = "Empresas Pymes") ]
        [Range (0,100,ErrorMessage ="Valor fuera de Rango")]
        public Nullable<float> FactoringPymes  { get; set; }

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
        [Display(Name = "Empresas Pymes")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> ConfirmingPymes { get; set; }

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
        [Display(Name = "Empresas Pymes")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> CobranzaDelegadaPymes { get; set; }

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
        public Nullable<float> TasaSpreadBolsaProductos { get; set; }

            
        [Required]
        [Display(Name = "Pymes")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> ComisionPyme { get; set; }
        
        [Required]
        [Display(Name = "Banca Empresa")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> ComisionBancaEmpresa { get; set; }
        
        [Required]
        [Display(Name = "Tipo Moneda")]
        public virtual string ComisionTipoMoneda { get; set; }
        
        [Required]
        [Display(Name = "Notaría Deudor")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> GastosNotariaDeudor { get; set; }

        [Required]
        [Display(Name = "Notaría N° Facturas")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public Nullable<float> GastosNotariaNFacturas { get; set; }

        [Required]
        [Display(Name = "Tipo Moneda")]
        public virtual string GastosTipoMoneda { get; set; }
        

    }
}
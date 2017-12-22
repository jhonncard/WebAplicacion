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
        public decimal? FactoringPymes  { get; set; }

        [Required]
        [Display(Name = "Empresas Medianas")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public decimal? FactoringMedianas { get; set; }

        [Required]
        [Display(Name = "Empresas Grandes")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public decimal? FactoringGrandes { get; set; }

        [Required]
        [Display(Name = "Empresas Coorporativas")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public decimal? FactoringCoorporativas { get; set; }

        [Required]
        [Display(Name = "Empresas Inmobiliarias")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public decimal? FactoringInmobiliarias { get; set; }

        /* CONFIRMING */
        [Required]
        [Display(Name = "Empresas Pymes")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public decimal? ConfirmingPymes { get; set; }

        [Required]
        [Display(Name = "Empresas Medianas")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public decimal? ConfirmingMedianas { get; set; }

        [Required]
        [Display(Name = "Empresas Grandes")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public decimal? ConfirmingGrandes { get; set; }

        [Required]
        [Display(Name = "Empresas Coorporativas")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public decimal? ConfirmingCoorporativas { get; set; }

        [Required]
        [Display(Name = "Empresas Inmobiliarias")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public decimal? ConfirmingInmobiliarias { get; set; }

        /* COMBRANZA DELEGADA  */
        [Required]
        [Display(Name = "Empresas Pymes")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public decimal? CobranzaDelegadaPymes { get; set; }

        [Required]
        [Display(Name = "Empresas Medianas")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public decimal? CobranzaDelegadaMedianas { get; set; }

        [Required]
        [Display(Name = "Empresas Grandes")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public decimal? CobranzaDelegadaGrandes { get; set; }

        [Required]
        [Display(Name = "Empresas Coorporativas")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public decimal? CobranzaDelegadaCoorporativas { get; set; }

        [Required]
        [Display(Name = "Empresas Inmobiliarias")]
        [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public decimal? CobranzaDelegadaInmobiliarias { get; set; }

        
        [Required]
        [Display(Name = "Bolsa de productos")]
       // [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public decimal? TasaSpreadBolsaProductos { get; set; }

            
        [Required]
        [Display(Name = "Pymes")]
       // [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public decimal? ComisionPyme { get; set; }
        
        [Required]
        [Display(Name = "Banca Empresa")]
      //  [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public decimal? ComisionBancaEmpresa { get; set; }
        
        [Required]
        [Display(Name = "Tipo Moneda")]
        public virtual string ComisionTipoMoneda { get; set; }
        
        [Required]
        [Display(Name = "Notaría Deudor")]
       // [Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public decimal? GastosNotariaDeudor { get; set; }

        [Required]
        [Display(Name = "Notaría N° Facturas")]
        //[Range(0, 100, ErrorMessage = "Valor fuera de Rango")]
        public decimal? GastosNotariaNFacturas { get; set; }

        [Required]
        [Display(Name = "Tipo Moneda")]
        public virtual string GastosTipoMoneda { get; set; }
        

    }
}
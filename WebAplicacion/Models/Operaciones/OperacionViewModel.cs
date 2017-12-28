using System;
using System.ComponentModel.DataAnnotations;


namespace WebAplicacion.Models.Operaciones
{
    public class OperacionViewModel
    {
        [Key]
        [Required]
        [Display(Name = "Rut Cliente")]
        public string  RutCliente { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Categoría Eempresa")]
        public string CategoríaEempresa{ get; set; }	


        [Required]
        [Display(Name = "Costo Fondo")]
        public decimal? Costo_Fondo { get; set; }

        [Required]
        [Display(Name = "Tipo de Operación")]
        public string  TipoOperacion { get; set; }

        [Required]
        public string Cobranza { get; set; }

        [Required]
        [Display(Name = "Costo Spread")]
        public decimal? CostoSpread  { get; set; }

        [Required]
        public string Responsabilidad { get; set; }

        [Required]
        [Display(Name = "Seguro")]
        public string Seguro { get; set; }

        [Required]
        [Display(Name = "Fecha Operación")]
        public DateTime? FechaOperacion { get; set; }

        [Required]
        [Display(Name = "Codigo Moneda")]
        public string CodigoMoneda { get; set; }

        [Required]
        [Display(Name = "Aviso Venc")]
        public string  sAvisoVenc { get; set; }

        [Required]
        public decimal? vAvisoVenc { get; set; }

        [Required]
        [Display(Name = "Tipo Documento")]
        public string  TipoDocumento { get; set; }

        [Required]
        [Display(Name = "Notificación")]
        public string sNotificacion { get; set; }

        [Required]
        public decimal? vNotificacion { get; set; }

        [Required]
        [Display(Name = "Comisión")]
        public decimal? Comision { get; set; }

        [Required]
        [Display(Name = "Comisión Min.")]
        public decimal? ComisionMin { get; set; }

        [Required]
        [Display(Name = "Comisión Max.")]
        public decimal? ComisionMax { get; set; }

        [Required]
        [Display(Name = "Tasa Operación")]
        public decimal?  TasaOperacion { get; set; }

        [Required]
        [Display(Name = "% Finaciemiento")]
        public decimal? Finaciemientoxc { get; set; }

        [Required]
        [Display(Name = "Gtos Oper.")]
        public decimal? Gastosope { get; set; }

        [Required]
        [Display(Name= "Monto Remesa")]
        public decimal? MontoRemesa { get; set; }

        [Required]
        [Display(Name = "Aument Art 84")]
        public string AumentArt84 { get; set; }

      
        [Required]
        [Display(Name = "Total Documentos")]
        public int? TotalDoc { get; set; }

        [Required]
        [Display(Name = "Total Not. x Dcto.")]
        public decimal? TotalNotDcto { get; set; }

        [Required]
        [Display(Name = "Total Acumulado")]
        public decimal? TotalAcum { get; set; }

        [Required]
        [Display(Name = "N° Deudores")]
        public int? Ndeudores { get; set; }

        [Required]
        [Display(Name = "Total Not. x Deudor")]
        public decimal? TotalNotDeudor { get; set; }

     }
}
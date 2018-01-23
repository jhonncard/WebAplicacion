using System;
using System.ComponentModel.DataAnnotations;
using Org.BouncyCastle.Crypto.Engines;


namespace WebAplicacion.Models.Operaciones
{
    public class OperacionViewModel
    {
    
        [Required]
        [Display(Name = "Rut Cliente")]
        public string  RutCliente { get; set; }

        [Required]
        //[Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Categoría Empresa")]
        public int CategoríaEempresa{ get; set; }	


        //[Required]
        [Display(Name = "Costo Fondo")]
//        [DisplayFormat(ApplyFormatInEditMode = true)]
        public decimal? Costo_Fondo { get; set; }

        [Required]
        [Display(Name = "Tipo de Operación")]
        [Range(1,100, ErrorMessage = "selecciones una opción")]
        public int  TipoOperacion { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "selecciones una opción")]
        public string Cobranza { get; set; }

       // [Required]
        [Display(Name = "Costo Spread")]
       public decimal? CostoSpread  { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "selecciones una opción")]
        public string Responsabilidad { get; set; }

        [Required]
        [Display(Name = "Seguro")]
        [Range(1, 100, ErrorMessage = "selecciones una opción")]
        public string Seguro { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "01/01/1900", "01/01/2099",
        ErrorMessage = "Fechas aceptadas para campo {0} entre {1} y {2}")]
        [Display(Name = "Fecha Operación")]
        //[DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaOperacion { get; set; }

        [Required]
        [Display(Name = "Codigo Moneda")]
        [Range(1, 100, ErrorMessage = "selecciones una opción")]
        public string CodigoMoneda { get; set; }

        [Required]
        [Display(Name = "Aviso Venc")]
        public string  sAvisoVenc { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public decimal? vAvisoVenc { get; set; }

        [Required]
        [Display(Name = "Tipo Documento")]
        [Range(1, 100, ErrorMessage = "selecciones una opción")]
        public int  TipoDocumento { get; set; }

        [Required]
        [Display(Name = "Notificación")]
        public string sNotificacion { get; set; }

      //  [Required]
        //[DisplayFormat(ApplyFormatInEditMode = true)]
        public decimal? vNotificacion { get; set; }

        //[Required]
        [Display(Name = "Comisión")]
        //[DisplayFormat(ApplyFormatInEditMode = true)]
        public decimal? Comision { get; set; }

        //[Required]
        [Display(Name = "Comisión Min.")]
        //[DisplayFormat(ApplyFormatInEditMode = true)]
        public decimal? ComisionMin { get; set; }

        //[Required]
        [Display(Name = "Comisión Max.")]
        //[DisplayFormat(ApplyFormatInEditMode = true)]
        public decimal? ComisionMax { get; set; }

        //[Required]
        [Display(Name = "Tasa Operación")]
        [Range( 0, 100, ErrorMessage = "El valor de {0} debe estar entre {1} y {2}")]
        //[DisplayFormat(ApplyFormatInEditMode = true)]
        public decimal?  TasaOperacion { get; set; }

        [Required]
        [Display(Name = "% Finaciamiento")]
        [Range(0, 100, ErrorMessage = "El valor de {0} debe estar entre {1} y {2}")]
        //[DisplayFormat(ApplyFormatInEditMode = true)]
        public decimal? Financiamiento { get; set; }

        //[Required]
        [Display(Name = "Gtos Oper.")]
        //[DisplayFormat(ApplyFormatInEditMode = true)]
        public decimal? Gastosope { get; set; }

        //[Required]
        [Display(Name= "Monto Remesa")]
        //[DisplayFormat(ApplyFormatInEditMode = true)]
        public decimal? MontoRemesa { get; set; }

        //[Required]
        [Display(Name = "Aumento Art 84")]
        public int AumentArt84 { get; set; }

      
      
        [Display(Name = "Total Documentos")]
        public int? TotalDoc { get; set; }

      
        [Display(Name = "Total Not. x Dcto.")]
        // [DisplayFormat(ApplyFormatInEditMode = true)]
        public decimal? TotalNotDcto { get; set; }

       
        [Display(Name = "Total Acumulado")]
         // [DisplayFormat(ApplyFormatInEditMode = true)]
        public decimal? TotalAcum { get; set; }

        
        [Display(Name = "N° Deudores")]
        public int? Ndeudores { get; set; }

      
        [Display(Name = "Total Not. x Deudor")]
       // [DisplayFormat(ApplyFormatInEditMode = true)]
        public decimal? TotalNotDeudor { get; set; }

        [ScaffoldColumn(false)]
        public string Guardar { get; set; }

        [ScaffoldColumn(false)]
        public string Mensajes { get; set; }
    }
}
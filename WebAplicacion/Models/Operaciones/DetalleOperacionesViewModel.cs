using System;
using System.ComponentModel.DataAnnotations;


namespace WebAplicacion.Models.Operaciones
{
    public class DetalleOperacionesViewModel
    {
        [Key]
        [Required]  
        [Display(Name = "Rut Deudor")]
        public string  RutDeudor { get; set; }

        [Required]
        [Display(Name = "N° Documento")]
        public string NroDocumento { get; set; }

        [Required]
        public decimal? Monto { get; set; }

        [Required]
        [Display(Name = "Fecha de Emision")]
        public DateTime FechaEmision { get; set; }

        [Required]
        [Display(Name = "Fecha de Vencimiento")]
        public DateTime FechaVencimeinto { get; set; }

        [Required]
        public string Pais { get; set; }

        [Required]
        public string Ciudad { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Direccion { get; set; }


        [ScaffoldColumn(false)]
        public string Rutcliente { get; set; }


        [ScaffoldColumn(false)]
        public int? NroOperacio { get; set; }

   

    }
}
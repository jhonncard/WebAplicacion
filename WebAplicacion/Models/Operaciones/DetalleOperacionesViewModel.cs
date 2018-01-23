using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAplicacion.Models.Dto;


namespace WebAplicacion.Models.Operaciones
{
    public class DetalleOperacionesViewModel
    {
       
        [Required]  
        [Display(Name = "Rut Deudor")]
        public string  RutDeudor { get; set; }

        [Required]
        [Display(Name = "N° Documento")]
        [Range(1,999999999999)]
        public int? NroDocumento { get; set; }

        [Required]
        [Range(1, 999999999999)]
        public decimal? Monto { get; set; }

        [Required]
        
        [Display(Name = "Fecha de Emision")]
        public DateTime? FechaEmision { get; set; }

        [Required]
        [Display(Name = "Fecha de Vencimiento")]
        public DateTime? FechaVencimeinto { get; set; }

        [Required]
        public int? Pais { get; set; }

        [Required]
        public string Plaza { get; set; }

        [ScaffoldColumn(false)]
        public string Ciudad { get; set; }

        [Required]
        public string Nombre { get; set; }

        [ScaffoldColumn(false)]
        public string Direccion { get; set; }
        
        [ScaffoldColumn(false)]
        public string Rutcliente { get; set; }
        
        [ScaffoldColumn(false)]
        public int? NroOperacio { get; set; }

        [ScaffoldColumn(false)]
        public string  MensajeNotificaciones { get; set; }

        [ScaffoldColumn(false)]
        public string RutDeudorClass { get; set; }

        [ScaffoldColumn(false)]
        public string NroDocumentoClass { get; set; }


        [ScaffoldColumn(false)]
        public string MontoClass { get; set; }


        [ScaffoldColumn(false)]
        public string FechaEmisionClass { get; set; }


        [ScaffoldColumn(false)]
        public string FechaVencimeintoClass { get; set; }


        [ScaffoldColumn(false)]
        public string PaisClass { get; set; }


        [ScaffoldColumn(false)]
        public string PlazaClass { get; set; }

        [ScaffoldColumn(false)]
        public string CiudadClass { get; set; }


        [ScaffoldColumn(false)]
        public string NombreClass { get; set; }

        [ScaffoldColumn(false)]
        public string DireccionClass { get; set; }
      
    }
}
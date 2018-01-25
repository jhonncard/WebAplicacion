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
         public string NroDocumento { get; set; }

        [Required]
        [Range(1, 9999999999999999)]
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

        ///////////////////////////////////////////////////////////

        public string RutDeudorNoti { get; set; }

        [ScaffoldColumn(false)]
        public string NroDocumentoNoti { get; set; }


        [ScaffoldColumn(false)]
        public string MontoNoti { get; set; }


        [ScaffoldColumn(false)]
        public string FechaEmisionNoti { get; set; }


        [ScaffoldColumn(false)]
        public string FechaVencimeintoNoti { get; set; }


        [ScaffoldColumn(false)]
        public string PaisNoti { get; set; }


        [ScaffoldColumn(false)]
        public string PlazaNoti { get; set; }

        [ScaffoldColumn(false)]
        public string CiudadNoti { get; set; }


        [ScaffoldColumn(false)]
        public string NombreNoti { get; set; }

        [ScaffoldColumn(false)]
        public string DireccionNoti { get; set; }
    }
}
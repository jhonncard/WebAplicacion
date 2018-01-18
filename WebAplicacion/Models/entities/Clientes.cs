using System;
using System.ComponentModel.DataAnnotations;

namespace WebAplicacion.Models.entities
{
    public class ClienteEntidad
    {
       public string Rut { get; set; }

        public string Nombre { get; set; }

        public string Pais { get; set; }
        
        public string Plaza { get; set; }

        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        
    }
}
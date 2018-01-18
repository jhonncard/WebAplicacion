using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models.Dto
{
    public class Respuesta
    {
        public DateTime Fecha { get; set; }
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public string Descripcion { get; set; }
        public string Excepction { get; set; }
    }
}
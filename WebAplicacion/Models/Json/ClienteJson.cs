using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models.Json
{
    public class ClienteJson
    {
       
     
        public string rut { get; set; }

       
        public string cliente { get; set; }

        
        public bool bloqueo { get; set; }

    
        public int? desde { get; set; }

        
        public int? hasta { get; set; }

        public string clasificacion { get; set; }     

        public decimal? retencion { get; set; }

    }
}
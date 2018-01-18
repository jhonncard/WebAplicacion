using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models.Dto
{
    public class Notificaciones
    {
        [ScaffoldColumn(false)]
        public string CamposNotificacion { get; set; }

        [ScaffoldColumn(false)]
        public string MensajesNotificacion { get; set; }



    }
}
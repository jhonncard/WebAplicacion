﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebAplicacion.Models
{
    public class TipoViewModel
    {
       
        public Nullable<int> id { get;  }

        [Display(Name = "Tipo deudor")]
        public string  Glosa { get; set; }
    }
}

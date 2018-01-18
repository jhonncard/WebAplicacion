using System;


namespace WebAplicacion.Models.entities
{
    public class DatosImpreson
    {
        public DateTime? FechaNac { get; set; }
        public DateTime? FechaInter { get; set; }
        public int?  CodNotaria { get; set; }
        public decimal? Tasa { get; set; }
        public string Descripcion { get; set; }
        public string  NombreNotario  { get; set; }
    }
}
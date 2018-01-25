using System;
using System.Collections.Generic;
using System.Linq;
using WebAplicacion.Models.Operaciones;

namespace WebAplicacion.util
{
    public static class Util
    {
        #region Valida Rut
        
        private static string CalcularDigitoVerificador(string  numero)
        {
            var cadenaNumero = numero.ToString();
            var calculador = 0;

            int[] factores = { 3, 2, 7, 6, 5, 4, 3, 2 };
            var indiceFactor = factores.Length - 1;

            for (var i = cadenaNumero.Length - 1; i >= 0; i--)
            {
                calculador = calculador + (factores[indiceFactor] * Int32.Parse(cadenaNumero.Substring(i, 1)));
                indiceFactor--;
            }

            string digitoVerificador;
            var resultado = 11 - (calculador % 11);

            switch (resultado)
            {
                case 11:
                    digitoVerificador = "0";
                    break;
                case 10:
                    digitoVerificador = "K";
                    break;
                default:
                    digitoVerificador = resultado.ToString();
                    break;
            }

            return digitoVerificador;
        }
        #endregion

        #region Valida si el rut es valido
        public static bool ObtenerValidezRut(string  rut, string dv)
        {
            return dv.ToUpper() == CalcularDigitoVerificador(rut);
        }
        #endregion

        #region Formatear Rut
        public static String formatearRut(String rut)
        {
            if (rut.Length == 9 || rut.Length == 8 || rut.Length == 2)
            {
                String[] FRut = new String[4];

                if (rut.Length == 9)
                {
                    FRut[0] = rut.Substring(0, 2);
                    FRut[1] = rut.Substring(2, 3);
                    FRut[2] = rut.Substring(5, 3);
                    FRut[3] = rut.Substring(8, 1);
                }

                if (rut.Length == 8)
                {
                    FRut[0] = rut.Substring(0, 1);
                    FRut[1] = rut.Substring(1, 3);
                    FRut[2] = rut.Substring(4, 3);
                    FRut[3] = rut.Substring(7, 1);
                }

                if (rut.Length == 2)
                {
                    FRut[0] = rut.Substring(0, 1);
                    FRut[1] = rut.Substring(1, 1);

                    rut = (FRut[0] + "-" + FRut[1]);

                    return rut;
                }

                rut = (FRut[0] + "." + FRut[1] + "." + FRut[2] + "-" + FRut[3]);
            }

            return rut;
        }
        #endregion  

        #region Validaciones de fechas

        public static bool FechaValida(string fecha)
        {
            DateTime _fecha;

            return DateTime.TryParse(fecha, out _fecha);

        }
        #endregion
    
        #region valorduplicadoLista no terminado

        public static string RegistrosRepetidos(List<DetalleOperacionesViewModel> detalle, DetalleOperacionesViewModel reg )
        {
          var inf = "";

            var copia = new DetalleOperacionesViewModel();
            var i = 0;
            foreach (var item in detalle)
            {
                if (reg.NroDocumento.Equals(item.NroDocumento) )
                {
                    i++;

                    if (i > 1)
                    {
                        i++;
                        inf = "Registro repetido";
                        
                    }
                }
               


            }
            return inf ;
        }


        #endregion

        #region diferenciade fechas a dias
        public static int Diffechas(DateTime fecha1, DateTime fecha2)
        {
            var val = 0;

            val = (int)(fecha2 - fecha1).Days;

            return val;
        }
        #endregion

        
    }

}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using WebAplicacion.Models.Operaciones;


namespace WebAplicacion.util
{
    public static class Util
    {
        #region rut
        
        private static string CalcularDigitoVerificador(string  numero)
        {
            var cadenaNumero = numero.ToString();
            var calculador = 0;

            int[] factores = { 3, 2, 7, 6, 5, 4, 3, 2 };
            var indiceFactor = factores.Length - 1;

            for (var i = cadenaNumero.Length - 1; i >= 0; i--)
            {
                calculador = calculador + (factores[indiceFactor] * int.Parse(cadenaNumero.Substring(i, 1)));
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


        #region Validaciones de fechas

        public static bool FechaValida(string fecha)
        {
            DateTime _fecha;

            return DateTime.TryParse(fecha, out _fecha);

        }

      





        #endregion

    }
}
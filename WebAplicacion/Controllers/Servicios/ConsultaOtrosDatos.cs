using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;

namespace WebAplicacion.Controllers.Servicios
{
    public class ConsultaOtrosDatos
    {
        private readonly HttpClient _cliente = new HttpClient();

        public async Task<string> MedioPago(int paramd0, string paramd1, int paramd2)
        {

            var searchResult = "";
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync("http://localhost:8080/WS_FactoringCargaMasiva/Helpers/ConsultarMedioDePago/"+paramd0+"?rut="+paramd1+"&moneda=" + paramd2);
                var desjson = JObject.Parse(json);
                //falta buscar valor del string 
                searchResult = (string)desjson["dtoResponseCodigosEstadoHttp"]["dtoResponseSetResultados"]["MedioDePago"];
                searchResult = (string)desjson["dtoResponseCodigosEstadoHttp"]["dtoResponseSetResultados"]["Glosa"];
            }
            catch (Exception)
            {
                ;
            }

            return searchResult;

        }
        public async Task<decimal> LeerBanco(int paramd0, string paramd1)
        {

            decimal searchResult = 0;
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await _cliente.GetStringAsync(" http://localhost:8080/WS_FactoringCargaMasiva/Helpers/ConsultarValorMoneda/"+paramd0+"?fecha=" + paramd1);
                var desjson = JObject.Parse(json);
                //falta buscar valor del string 
                searchResult = (decimal)desjson["dtoResponseCodigosEstadoHttp"]["Valor"];
            }
            catch (Exception)
            {
                ;
            }

            return searchResult;

        }
       
    }
}
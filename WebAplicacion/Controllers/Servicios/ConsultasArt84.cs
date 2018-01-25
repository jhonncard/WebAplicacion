using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WebAplicacion.Models.entities;
using WebAplicacion.Models.Json;

namespace WebAplicacion.Controllers.Servicios
{
    public class ConsultasArt84
    {
        private readonly HttpClient _cliente = new HttpClient();





        public async Task<VerificaLimites84> ValidarGrabadoSimulacion(VerificaLimites84Jason vgs)
        {

            var searchResults = new VerificaLimites84();
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                 var json = await _cliente.PostAsJsonAsync(ConfigurationManager.AppSettings["servicioBase"] + "/WS_FactoringCargaMasiva/Helpers/LimitesArt84Bac", vgs);
                var desjson = JObject.Parse(json.ToString());
                searchResults.Estado =(string) desjson["dtoResponseSetResultados"]["Estado"];
                searchResults.Mensaje = (string)desjson["dtoResponseSetResultados"]["Mensaje"];
                searchResults.Monto1 = (decimal)desjson["dtoResponseSetResultados"]["Monto1"];
                searchResults.Monto2 = (decimal)desjson["dtoResponseSetResultados"]["Monto2"];
            }
            catch (Exception)
            {
                ;
            }

            return searchResults;

        }
    }
}
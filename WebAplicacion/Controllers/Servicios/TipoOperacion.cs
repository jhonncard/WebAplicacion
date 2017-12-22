using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using WebAplicacion.Models;


namespace WebAplicacion.Controllers.Servicios
{
    public class TipoOperacion
    {
       private readonly HttpClient _cliente = new HttpClient();

        //public async Task<List<SelectListItem> Tipo_Operacion()
        //{

        //    return await llamarServicios(1);
        //}




        private async Task<List<SelectListItem>> llamarServicios(int tipo)
        {
            var searchResults = new List<SelectListItem>();
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-AuthorizationOPE"]);
                var json = await _cliente.GetStringAsync("http://10.250.13.245:8080/WS_FactoringCargaMasiva/ConsultarDatosOperacion/" + tipo);
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoDatosOperacion"].Children().ToList();
                foreach (var result in results)
                {
                    var searchResult = result.ToObject<SelectListItem>();
                    searchResults.Add(searchResult);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return searchResults;
        }

    }
    
}
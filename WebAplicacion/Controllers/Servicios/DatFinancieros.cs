using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace WebAplicacion.Controllers.Servicios
{
    public class DatFinancieros
    {
        private readonly HttpClient _cliente = new HttpClient();

        public async Task<List<SelectListItem>> DatosFinancieros(string rut, int tipodoc, int moneda )
        {
            
            return await LlamarServicios(rut, tipodoc,moneda);
        }

       

        private async Task<List<SelectListItem>> LlamarServicios(string rut, int tipodoc, int moneda)
        {
            var searchResults = new List<SelectListItem>();
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-AuthorizationOPE"]);
                var json = await _cliente.GetStringAsync("http://10.250.13.245:8080/WS_FactoringCargaMasiva/ConsultarDatosFinancieros/"+rut+"?doc="+tipodoc+"&moneda="+moneda);
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoDatosFinancieros"].Children().ToList();
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

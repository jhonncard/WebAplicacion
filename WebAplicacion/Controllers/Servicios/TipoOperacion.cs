using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;



namespace WebAplicacion.Controllers.Servicios
{
    public  class TipoOperacion
    {
       private readonly HttpClient _cliente = new HttpClient();

        public List<SelectListItem> Tipo_Operacion()
        {

            return  LlamarServicios(1).Result;
        }

        public Task<List<SelectListItem>> Cobranza()
        {

            return  LlamarServicios(2);
        }

        public Task<List<SelectListItem>> Responsabilidad()
        {

            return  LlamarServicios(3);
        }

        public Task<List<SelectListItem>> Seguro()
        {

            return  LlamarServicios(4);
        }

        private async  Task<List<SelectListItem>> LlamarServicios(int tipo)
        {
            var searchResults = new List<SelectListItem>();
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", "SaFbnm9FjPwmoJnFxM1q1O3thkclzIUmT4TLycceFZcQ9ama");
                var json =await  _cliente.GetStringAsync("http://10.250.13.245:8080/WS_FactoringCargaMasiva/ConsultarDatosOperacion/" + tipo);
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

                var searchResult = new SelectListItem();
                searchResults.Add(searchResult);
            }
            return searchResults;
        }

    }
    
}
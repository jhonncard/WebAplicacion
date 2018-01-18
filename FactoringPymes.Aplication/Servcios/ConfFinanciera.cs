using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using WebAplicacion.Models.Json;

namespace WebAplicacion.Controllers.Servicios
{
    public class ConfFinanciera
    {
        private readonly HttpClient _cliente = new HttpClient();

        public async Task<List<SelectListItem>> Documentos()
        {
            return await LlamarServicios("dtoDocumentos");
        }

        public async Task<List<SelectListItem>> Monedas()
        {
            return await LlamarServicios("dtoMonedas");
        }

        public async Task<List<SelectListItem>> Empresas()
        {
            return await LlamarServicios("dtoEmpresas");
        }
        public async Task<string> FechaProceso()
        {
            var fechas =  await LlamarServicios("FechaProceso");
           var fecha = fechas.First().Text;
           return fecha;
        }

        private async Task<List<SelectListItem>> LlamarServicios(string hijo)
        {
            var searchResultscf = new List<datoscofig>();
            var searchResults = new List<SelectListItem>();
            
            try
            {
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                _cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-AuthorizationOPE"]);
                var json = await _cliente.GetStringAsync("http://10.250.13.245:8080/WS_FactoringCargaMasiva/ConsultarConfigFinanciera/" );
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"][hijo].Children().ToList();
                if (hijo == "FechaProceso")
                {
                   var items = new datoscofig();
                    items.FechaProceso = (string)desjson["dtoResponseSetResultados"]["FechaProceso"];
                    items.Id = "1";
                    searchResultscf.Add(items);
                }
                foreach (var result in results)
                {
                    var searchResult = result.ToObject<datoscofig>();
                    searchResultscf.Add(searchResult);
                }

            }
            catch (Exception )
            {
                var searchResult = new datoscofig();
                searchResultscf.Add(searchResult);

            }

            foreach (var item in searchResultscf)
            {
               var  items = new SelectListItem();
                switch (hijo)
                {
                    case "dtoDocumentos":
                        items.Text = item.GlosaDocumento.Trim();
                        items.Value = item.CodigoDocumento;
                        
                        break;
                    case "dtoMonedas":
                        items.Text = item.GlosaMoneda.Trim();
                        items.Value = item.CodigoMoneda;
                        
                        break;
                    case "dtoEmpresas":

                        items.Text = item.GlosaEmpresa.Trim();
                        items.Value = item.Id;
                        
                        break;
                    case "FechaProceso":

                        items.Text = item.FechaProceso.Trim();
                        items.Value = item.Id.Trim(); 
                        break;

                }
                searchResults.Add(items);

            }

            return searchResults;
        }

    }




}
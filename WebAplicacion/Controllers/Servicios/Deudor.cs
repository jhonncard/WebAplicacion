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
    public class Deudor
    {
        private Mant_DuedoresViewModel clienteold = new Mant_DuedoresViewModel();

        private readonly HttpClient client = new HttpClient();

        public Deudor()
        {

        }



        public async Task<List<Mant_DuedoresViewModel>> ConsultarDeudor(int paramid, string id)
        {

          var searchResults = new List<Mant_DuedoresViewModel>();
            try
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization",
                    ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await client.GetStringAsync( "http://10.250.13.245:8080/WS_FactoringMantenedores/ConsultarDeudores/" + paramid + "?param=" + id);
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoCondicionesComerciales"].Children()
                    .ToList();
                foreach (var result in results)
                {
                    var searchResult = result.ToObject<Mant_DuedoresViewModel>();
                    searchResults.Add(searchResult);
                }

            }
            catch (Exception )
            {

                var searchResult = new Mant_DuedoresViewModel();
                searchResults.Add(searchResult);
            }


            return searchResults;

        }



        public async Task<Mant_DuedoresViewModel> ConsultarDeudorFac(string rut)
        {

           var searchResults = new List<Mant_DuedoresViewModel>();
            try
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization",
                    ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await client.GetStringAsync(
                    "http://10.250.13.245:8080/WS_FactoringMantenedores/ConsultarDeudoresFactoring/" + rut);
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoCondicionesComerciales"].Children()
                    .ToList();
                foreach (var result in results)
                {
                    Mant_DuedoresViewModel searchResult = result.ToObject<Mant_DuedoresViewModel>();
                    searchResults.Add(searchResult);
                }

            }
            catch (Exception )
            {
                var searchResult = new Mant_DuedoresViewModel();
                searchResults.Add(searchResult);
            }


            return searchResults.First();

        }
        
        public async Task GuardarDeudor(Mant_DuedoresViewModel modelo)
        {
            var reflex = new Reflectiones();
            if (await reflex.Comprar((ConsultarDeudorFac(modelo.Rut)), modelo, "user", "Deudores"))
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization",
                    ConfigurationManager.AppSettings["Token-Authorization"]);
                await client.PostAsJsonAsync ("http://10.250.13.245:8080/WS_FactoringMantenedores/GrabarDeudoresFactoring/", MapperMantMduedoresDto(modelo));

               
            }

      }

        public async Task<List<Mant_DuedoresViewModel>> GetDeudorPorNombre(int param,  string nombre)
        {
            var searchResults = new List<Mant_DuedoresViewModel>();
            try
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await client.GetStringAsync("http://10.250.13.245:8080/WS_FactoringMantenedores/ConsultarDeudores/"+param+"?param=" + nombre);
                JObject desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoClienteBAC"].Children().ToList();
                foreach (JToken result in results)
                {
                    Mant_DuedoresViewModel searchResult = result.ToObject<Mant_DuedoresViewModel>();
                    searchResults.Add(searchResult);
                }

            }
            catch (Exception)
            {

                var searchResult = new Mant_DuedoresViewModel();
                searchResults.Add(searchResult);
            }
            return searchResults;
        }






        private Mant_MduedoresDto MapperMantMduedoresDto(Mant_DuedoresViewModel deudor)
        {
            var _deudor = new Mant_MduedoresDto
            {

                Rut = deudor.Rut.ToString(),
                Cliente = deudor.Cliente,
                Bloqueo = deudor.Bloqueo ? 1 : 0,
                Sinacofi = deudor.Sinacofi ? 1 : 0,
                Dias = deudor.Dias,
                TipoDeudor = deudor.tipoDeudor,
                Clasificacion = deudor.Clasificacion,
                Aprobado = deudor.Aprobado,
                Utilizado = deudor.Utilizado,
                pago12 = deudor.pago12,
                pago6 = deudor.pago6,
                Mora12 = deudor.Mora12,
                Mora6 = deudor.Mora6,
                NroDoc12 = deudor.NroDoc12,
                NroDoc6 = deudor.NroDoc6

            };

            return _deudor;
        }


    }
}
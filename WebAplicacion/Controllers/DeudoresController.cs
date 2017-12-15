using WebAplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using System.Configuration;



namespace WebAplicacion.Controllers
{
    public class DeudoresController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Buscardeudor(string id)
        {
           
            var paramid = "0";
            try
            {
                long.Parse(id);
                paramid = "1";
            }
            catch (Exception e)
            {
                paramid = "0";
            }
            var cliente = new HttpClient();
            IList<Mant_DuedoresViewModel> searchResults = new List<Mant_DuedoresViewModel>();
            try
            {
              cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await cliente.GetStringAsync("http://10.250.13.245:8080/WS_FactoringMantenedores/ConsultarDeudores/" + paramid + "?" + id);
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoCondicionesComerciales"].Children().ToList();
                foreach (var result in results)
                {
                    Mant_DuedoresViewModel searchResult = result.ToObject<Mant_DuedoresViewModel>();
                    searchResults.Add(searchResult);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

           
            return View("Index", searchResults.First());
           
        }


        public async Task<ActionResult> BuscarDetalle(string rut)
        {
            var mcliente = new Mant_DuedoresViewModel();

            var cliente = new HttpClient();
            IList<Mant_DuedoresViewModel> searchResults = new List<Mant_DuedoresViewModel>();
            try
            {
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await cliente.GetStringAsync("http://10.250.13.245:8080/WS_FactoringMantenedores/ConsultarDeudoresFactoring/" + rut);
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoCondicionesComerciales"].Children().ToList();
                foreach (var result in results)
                {
                    Mant_DuedoresViewModel searchResult = result.ToObject<Mant_DuedoresViewModel>();
                    searchResults.Add(searchResult);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            
            return View("Index", searchResults.First());
            // return View(mcliente);
        }


        public async Task<ActionResult> GuardaResult(Mant_DuedoresViewModel modelo)
        {

            Reflectiones reflex = new Reflectiones();
            var cliente = new HttpClient();
            cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
            var response = await cliente.PostAsJsonAsync
                ("http://10.250.13.245:8080/WS_FactoringMantenedores/GrabarDeudoresFactoring/", (MapperMantMduedoresDto(modelo)));

           if (response.StatusCode.Equals(200))
              reflex.Comprar((Buscardatos(modelo.Rut.ToString())), modelo, "user", "Deudores");

            return View("Index", modelo);

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



        private static async Task<IList<Mant_DuedoresViewModel>> Buscardatos(string rut)
        {
            var cliente = new HttpClient();
            IList<Mant_DuedoresViewModel> searchResults = new List<Mant_DuedoresViewModel>();
            try
            {
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await cliente.GetStringAsync("http://10.250.13.245:8080/WS_FactoringMantenedores/ConsultarClienteFactoring/" + rut);
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoCondicionesComerciales"].Children().ToList();
                foreach (var result in results)
                {
                    Mant_DuedoresViewModel searchResult = result.ToObject<Mant_DuedoresViewModel>();
                    searchResults.Add(searchResult);
                }

            }
            catch (Exception ex)
            {
                var searchResult = new Mant_DuedoresViewModel();
                searchResults.Add(searchResult);
            }
            return searchResults;
        }
    }

  }

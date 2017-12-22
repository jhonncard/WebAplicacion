
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Web.Mvc;
using Factoring.Negocios;
using Newtonsoft.Json.Linq;
using WebAplicacion.Models;

namespace WebAplicacion.Controllers
{
    public class ClientesController : Controller
    {
        private Mant_ClientesViewModel clienteold = new Mant_ClientesViewModel();

        private readonly HttpClient cliente = new HttpClient();
        public ClientesController()
        {
            clienteold = new Mant_ClientesViewModel();
        }

           [HttpGet]
        public ActionResult Index()
           {
               ViewBag.TokenAuthorization = ConfigurationManager.AppSettings["Token-Authorization"];
            return View();
        }


        public async Task<ActionResult> Buscarcliente(string id)
        {        var mcliente = new Mant_ClientesViewModel();
            var paramid = "0";
            try
            {
                long.Parse(id);
                paramid = "1";
            }
            catch (Exception)
            {
                paramid = "0";
            }
         
            IList<Mant_ClientesViewModel> searchResults = new List<Mant_ClientesViewModel>();
            try
            {
               cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
               cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await cliente.GetStringAsync("http://10.250.13.245:8080/WS_FactoringMantenedores/ConsultarClienteBac/" + paramid + "?" + id);
                    JObject desjson = JObject.Parse(json);
                    IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoCondicionesComerciales"].Children().ToList();
                    foreach (JToken result in results)
                    {
                        Mant_ClientesViewModel searchResult = result.ToObject<Mant_ClientesViewModel>();
                        searchResults.Add(searchResult);
                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }

                 clienteold = searchResults.First();
                return View("Index",searchResults.First());
                // return View(mcliente);
        }

        public async Task<ActionResult> BuscarDetalle(string rut)
           {
             

            var cliente = new HttpClient();
               IList<Mant_ClientesViewModel> searchResults = new List<Mant_ClientesViewModel>();
               try
               {
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                   cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await cliente.GetStringAsync("http://10.250.13.245:8080/WS_FactoringMantenedores/ConsultarClienteFactoring/" + rut);
                   JObject desjson = JObject.Parse(json);
                   IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoCondicionesComerciales"].Children().ToList();
                   foreach (JToken result in results)
                   {
                       Mant_ClientesViewModel searchResult = result.ToObject<Mant_ClientesViewModel>();
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

        public async Task<ActionResult> GuardaResult(Mant_ClientesViewModel modelo)
           {
            var reflex = new Reflectiones();
               clienteold = await buscardatos(modelo.Rut);
               ViewBag.Mensaje = "Cambiso Guardados";
               if (!await reflex.Comprar(clienteold, modelo, "user", "condiciones")) return View("Index", modelo );
         
            cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
            HttpResponseMessage response = await cliente.PostAsJsonAsync
             ("http://10.250.13.245:8080/WS_FactoringMantenedores/GrabarCondicionesComerciales", (modelo));

              return View("Index",modelo);
               
           }






           public async Task<Mant_ClientesViewModel> buscardatos(string rut)
           {
               IList<Mant_ClientesViewModel> searchResults = new List<Mant_ClientesViewModel>();
            try
               {
                   cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                   cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                   var json = await cliente.GetStringAsync("http://10.250.13.245:8080/WS_FactoringMantenedores/ConsultarClienteFactoring/" + rut);
                   JObject desjson = JObject.Parse(json);
                   IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoCondicionesComerciales"].Children().ToList();
                   foreach (JToken result in results)
                   {
                       Mant_ClientesViewModel searchResult = result.ToObject<Mant_ClientesViewModel>();
                       searchResults.Add(searchResult);
                   }

               }
               catch (Exception )
               {

                var searchResult =new  Mant_ClientesViewModel();
                   searchResults.Add(searchResult);
            }

              return searchResults.First();
        }
        [HttpPost]
        [AllowAnonymous]
        public async  Task<JsonResult> GetClientePorNombre(string nombre)
        {
            IList<Mant_ClientesViewModel> searchResults = new List<Mant_ClientesViewModel>();
            try
            {
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                var json = await cliente.GetStringAsync("http://10.250.13.245:8080/WS_FactoringMantenedores/ConsultarClienteBac/0?param=" + nombre);
                JObject desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoClienteBAC"].Children().ToList();
                foreach (JToken result in results)
                {
                    Mant_ClientesViewModel searchResult = result.ToObject<Mant_ClientesViewModel>();
                    searchResults.Add(searchResult);
                }

            }
            catch (Exception)
            {

                var searchResult = new Mant_ClientesViewModel();
                searchResults.Add(searchResult);
            }
                return Json( new
                    {   Success = true,
                        Clientes = searchResults},
                    JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetClientePorRut(string nombre )
        {
            var rut = nombre;
                IList<Mant_ClientesViewModel> searchResults = new List<Mant_ClientesViewModel>();
                    try
                {
                    cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                    cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
                    var json = await cliente.GetStringAsync("http://10.250.13.245:8080/WS_FactoringMantenedores/ConsultarClienteBac/1?param=" + rut);
                    JObject desjson = JObject.Parse(json);
                    IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoClienteBAC"].Children().ToList();
                    foreach (JToken result in results)
                    {
                        Mant_ClientesViewModel searchResult = result.ToObject<Mant_ClientesViewModel>();
                        searchResults.Add(searchResult);
                    }

                }
            catch (Exception)
            {

            var searchResult = new Mant_ClientesViewModel();
            searchResults.Add(searchResult);
            }
            return Json(new
                {   Success = true,
                    Clientes = searchResults
                }, JsonRequestBehavior.AllowGet );
            }
    }
}

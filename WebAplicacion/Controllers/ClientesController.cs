
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
        private Mant_ClientesViewModel clienteold;

        public ClientesController()
        {
            clienteold = new Mant_ClientesViewModel();
        }

           [HttpGet]
        public ActionResult Index()
        {
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
            catch (Exception e)
            {
                paramid = "0";
            }
            var cliente = new HttpClient();
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
               var mcliente = new Mant_ClientesViewModel();
               
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

               clienteold = searchResults.First();
               return View("Index", searchResults.First());
               // return View(mcliente);
           }

        public async Task<ActionResult> GuardaResult(Mant_ClientesViewModel modelo)
           {
               
               Reflectiones reflex = new Reflectiones();
               var cliente = new HttpClient();
            cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
               cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-Authorization"]);
            HttpResponseMessage response = await cliente.PostAsJsonAsync
                   ("http://10.250.13.245:8080/WS_FactoringMantenedores/GrabarCondicionesComerciales", (modelo));

               //if (response.StatusCode.Equals(200))
               //    reflex.Comprar(oldmodel, modelo, "user", "condiciones");

               return View("Index",modelo);
               
           }


      
       
     
    }
}

    using WebAplicacion.Models;
using System;
using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace WebAplicacion.Controllers
{
    public class LogController : Controller
    {
       
        // GET: Factoring/Log
        public ActionResult Index()
        {
            return View();
        }

        // GET: Factoring/Log/Details/5
        public async Task<ActionResult> Details(ReporteViewModel repo)
        {
          var searchResults = new List<LoggersViewModel>();

            var buscar = "";

            if (repo.Clientes)
            {
                buscar = "Clientes";
                List<LoggersViewModel> x = await buscarlog(buscar);
                searchResults.AddRange(x);
            }
             if (repo.Clientes)
            {
                buscar = "Deudores";
                List<LoggersViewModel> x = await buscarlog(buscar);
                searchResults.AddRange(x);
            }
             if (repo.Condiciones)
            {
                buscar = "Condiciones";
                List<LoggersViewModel> x = await buscarlog(buscar);
                searchResults.AddRange(x);
            }
             if( buscar =="")
                return View(searchResults);
            if (searchResults.Any())
            {
                int i = 0;
                foreach (var Item in searchResults)
                {
                    Item.Id = ++i;

                }
            }
            return View(searchResults);
        }


        private async Task<List<LoggersViewModel>> buscarlog(string buscar  )
        {
            List<LoggersViewModel> searchResults = new List<LoggersViewModel>();

            try
            {
                var cliente = new HttpClient();
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", "mZCP5dT9sQn8gLK1IGcPS12xniDB9bcoC38pARZ29g6JZAXb");
                var json = await cliente.GetStringAsync(ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringMantenedores/ConsultarLogFactoring/" + buscar);
                JObject desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoConsultaLogFactoring"].Children().ToList();

                foreach (JToken result in results)
                {
                    LoggersViewModel searchResult = result.ToObject<LoggersViewModel>();
                    searchResults.Add(searchResult);

                }

            }
            catch (Exception )
            {
                LoggersViewModel searchResult = new LoggersViewModel();
                searchResults.Add(searchResult);
              //  throw ex;
            }
            return searchResults;
        }
      
    }
}

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
    public class CondicionesController : Controller
    {
        CondicionesFactoringViewModel oldmodel = new CondicionesFactoringViewModel();
        // GET: FactoringPyme/Condiciones
        public async Task<ActionResult> Index()
        {
            var cliente = new HttpClient();

            #region  lista para el dropdown list de monedas 
            var monedas = new List<MonedaViewModel>();

            string valores = ConfigurationManager.AppSettings["Monedas"].ToString();
            var separador = new char[] { ',' };
            var words = valores.Split(separador, StringSplitOptions.RemoveEmptyEntries);
            foreach(var valor in words)
            { 
              try {
                        cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                        cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", "mZCP5dT9sQn8gLK1IGcPS12xniDB9bcoC38pARZ29g6JZAXb");
                        var json = await cliente.GetStringAsync("http://10.250.13.245:8080/WS_FactoringMantenedores/ConsultarMoneda/" + valor );
                        var desjson = JObject.Parse(json);
                        IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoConsultarMoneda"].Children().ToList();
                        monedas.AddRange(results.Select(result => result.ToObject<MonedaViewModel>()));
                  }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
              }

            var i = 1;
            var listamonedas = monedas.Select(item => new SelectListItem
                {
                    Text = item.Simbolo.Trim(),
                    Value = i++.ToString()
                })
                .ToList();
            ViewBag.listamonedas = listamonedas;
            
            #endregion


            IList <CondicionesFactoringViewModel> searchResults = new List<CondicionesFactoringViewModel>();

            try
            {
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", "mZCP5dT9sQn8gLK1IGcPS12xniDB9bcoC38pARZ29g6JZAXb");
                var json = await cliente.GetStringAsync("http://10.250.13.245:8080/WS_FactoringMantenedores/ConsultarCondicionesComerciales");
                JObject desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoCondicionesComerciales"].Children().ToList();
                foreach (JToken result in results)
                {
                    CondicionesFactoringViewModel searchResult = result.ToObject<CondicionesFactoringViewModel>();
                    searchResults.Add(searchResult);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            oldmodel =  searchResults.First();
            return View(searchResults.First());
            // return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(CondicionesFactoringViewModel modelo)
        {
            Reflectiones reflex = new Reflectiones();
            var cliente = new HttpClient();
            cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", "mZCP5dT9sQn8gLK1IGcPS12xniDB9bcoC38pARZ29g6JZAXb");
            HttpResponseMessage response = await cliente.PostAsJsonAsync
                ("http://10.250.13.245:8080/WS_FactoringMantenedores/GrabarCondicionesComerciales", Mappercondiciones(modelo));

            //if (response.StatusCode.Equals(200))
            //    reflex.Comprar(oldmodel, modelo, "user", "condiciones");

            return View(modelo);
        }


        
        private CondicionescomercialesJson Mappercondiciones(CondicionesFactoringViewModel model)
        {
            var condiciones =
                new CondicionescomercialesJson
                {
                    factoringPymes = model.FactoringPymes.Value,
                    factoringMedianas = model.FactoringMedianas.Value,
                    factoringGrandes = model.FactoringGrandes.Value,
                    factoringCoorporativas = model.FactoringCoorporativas.Value,
                    factoringInmobiliarias = model.FactoringInmobiliarias.Value,
                    confirmingPymes = model.ConfirmingPymes.Value,
                    confirmingMedianas = model.ConfirmingMedianas.Value,
                    confirmingGrandes = model.ConfirmingGrandes.Value,
                    confirmingCoorporativas = model.ConfirmingCoorporativas.Value,
                    confirmingInmobiliarias = model.ConfirmingInmobiliarias.Value,
                    cobranzaDelegadaPymes = model.CobranzaDelegadaPymes.Value,
                    cobranzaDelegadaMedianas = model.CobranzaDelegadaMedianas.Value,
                    cobranzaDelegadaGrandes = model.CobranzaDelegadaGrandes.Value,
                    cobranzaDelegadaCoorporativas = model.CobranzaDelegadaCoorporativas.Value,
                    cobranzaDelegadaInmobiliarias = model.CobranzaDelegadaInmobiliarias.Value,
                    tasaSpreadBolsaProductos = model.TasaSpreadBolsaProductos.Value,
                    comisionPyme = model.ComisionPyme.Value,
                    comisionBancaEmpresa = model.ComisionBancaEmpresa.Value,
                    comisionTipoMoneda = model.ComisionTipoMoneda,
                    gastosNotariaDeudor = model.GastosNotariaDeudor.Value,
                    gastosNotariaNFacturas = model.GastosNotariaNFacturas.Value,
                    gastosTipoMoneda = model.GastosTipoMoneda
                };


            return condiciones;


        }
       
    }
}

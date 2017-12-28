using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using WebAplicacion.Controllers.Servicios;
using WebAplicacion.Models.Json;
using WebAplicacion.Models.Operaciones;

namespace WebAplicacion.Controllers
{
    public class OperacionController : Controller
    {
        private readonly HttpClient cliente = new HttpClient();

        private readonly Operacion _operacion = new Operacion();
     
        public OperacionController()
        {
            
        }
        //: Factoring/Operacion
        public async Task<ActionResult> Index()
        {
            var modelo = new ListCargaMasivaViewModels();
            modelo.Opercion = new OperacionViewModel();
            modelo.Doperaciones = new List<DetalleOperacionesViewModel>();
            var ope = new Operacion();
            var cofgf = new ConfFinanciera();
            ViewBag.tipooeracion = await LlamarServicios(1);
            ViewBag.responsabilidad = await LlamarServicios(2);
            ViewBag.cobranza = await LlamarServicios(3);
            ViewBag.seguro = await LlamarServicios(4);
            ViewBag.empresas = await cofgf.Empresas();
            ViewBag.fechaoperacion = await cofgf.FechaProceso();
            ViewBag.codigomoneda = await cofgf.Monedas();
            ViewBag.tiopodoc = await cofgf.Documentos();
            ViewBag.listasino = ope.LIstaSiNo();
            modelo.Opercion.Costo_Fondo = 0;
            modelo.Opercion.CostoSpread=0;
            modelo.Opercion.vAvisoVenc = 0;
            modelo.Opercion.vNotificacion = 0;
            modelo.Opercion.Comision = 0;
            modelo.Opercion.ComisionMin = 0;
            modelo.Opercion.ComisionMax = 0;
            modelo.Opercion.TasaOperacion = 0;
            modelo.Opercion.Finaciemientoxc = 0;
            modelo.Opercion.Gastosope = 0;
            modelo.Opercion.MontoRemesa = 0;
            modelo.Opercion.TotalDoc = 0;
            modelo.Opercion.TotalNotDcto = 0;
            modelo.Opercion.TotalNotDeudor = 0;
            modelo.Opercion.Ndeudores = 0;
            modelo.Opercion.TotalAcum = 0;
            
            var estyles = await cofgf.FechaProceso();
            modelo.Opercion.FechaOperacion = DateTime.Parse(estyles);
            return View(modelo);
        }

        // entrada inicial
        [HttpPost]
        public ActionResult Index(string rut_cliente)
        {
          var modelo=new ListCargaMasivaViewModels();
          var client = new Cliente();
            
          var mcliente = client.ConsultaClienteFac(rut_cliente);
            modelo.Opercion.RutCliente = rut_cliente;
            modelo.Opercion.Nombre = mcliente.Result.First().Cliente;
          



            return View(modelo);
        }

      //  guardardo
        [HttpPost]
        public ActionResult Index(ListCargaMasivaViewModels modelo)
        {
            
            return View();
        }

        public ActionResult Listaoperaciones(int? id )
        {
            if (id == null)
            {
                
                return View();
            }
            else
            {
                return RedirectToAction("Index", "ExcepcionOperacion", id);
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////


       private async Task<List<SelectListItem>> LlamarServicios(int tipo)
        {
          var  searchResults = new List<SelectListItem>();
            var searchResultsdatos = new List<Datos>();
            try
            {
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", ConfigurationManager.AppSettings["Token-AuthorizationOPE"]);
               var json = await cliente.GetStringAsync("http://10.250.13.245:8080/WS_FactoringCargaMasiva/ConsultarDatosOperacion/" + tipo);
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoDatosOperacion"].Children().ToList();
                foreach (var result in results)
                {
                   var searchResult = result.ToObject<Datos>();
                    searchResultsdatos.Add(searchResult);
                }

            }
            catch (Exception ex)
            {

                var searchResult = new Datos();
                searchResultsdatos.Add(searchResult);
            }

            foreach (var item in searchResultsdatos)
            {
                var items = new SelectListItem();

                items.Text = item.Glosa.Trim();
                items.Value = item.Id.ToString();
                searchResults.Add(items);
            }

            return searchResults;
        }

        
        [HttpPost]
        public ActionResult UpdActionResult(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                        Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        }




    }
}

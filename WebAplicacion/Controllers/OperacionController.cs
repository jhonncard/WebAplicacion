using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Mvc;
using System.Web.WebPages;
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
            var modelo = new ListCargaMasivaViewModels
            {
                Opercion = new OperacionViewModel(),
                Doperaciones = new List<DetalleOperacionesViewModel>()
            };
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

            //modelo.Opercion.Costo_Fondo = 0;
            //modelo.Opercion.CostoSpread = 0;
            //modelo.Opercion.vAvisoVenc = 0;
            //modelo.Opercion.vNotificacion = 0;
            //modelo.Opercion.Comision = 0;
            //modelo.Opercion.ComisionMin = 0;
            //modelo.Opercion.ComisionMax = 0;
            //modelo.Opercion.TasaOperacion = 0;
            //modelo.Opercion.Finaciemientoxc = 0;
            //modelo.Opercion.Gastosope = 0;
            //modelo.Opercion.MontoRemesa = 0;
            //modelo.Opercion.TotalDoc = 0;
            //modelo.Opercion.TotalNotDcto = 0;
            //modelo.Opercion.TotalNotDeudor = 0;
            //modelo.Opercion.Ndeudores = 0;
            //modelo.Opercion.TotalAcum = 0;

            //var estyles = await cofgf.FechaProceso();
            //modelo.Opercion.FechaOperacion = estyles.AsDateTime();
            return View(modelo);
        }

        // entrada inicial
        //[HttpPost]
        //public async Task<ActionResult> Index(string rut_cliente)
        //{
        //    var modelo = new ListCargaMasivaViewModels();
        //    var client = new Cliente();

        //    var mcliente = await client.ConsultaClienteFac(rut_cliente);
        //    modelo.Opercion.RutCliente = rut_cliente;
        //    modelo.Opercion.Nombre = mcliente.First().Cliente;

        //    return View(modelo);
        //}


        public FileResult Descargar()
        {
            var ruta = Server.MapPath("~/Files/salida/cargaMasivo.xls");
            return File(ruta, "application/xls", "cargaMasivo.xls");
        }


        public HttpStatusCodeResult Error()
        {
            return new HttpStatusCodeResult(404, "Recurso no encontrado");
        }



        //  guardardo
        [HttpPost]
        public async Task<ActionResult> Index(  ListCargaMasivaViewModels model , HttpPostedFileBase archivo)
        {
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
            if (archivo == null || archivo.ContentLength <= 0) return Redirect("Index");
                if (!(archivo.FileName.EndsWith("xls")))
                {
                    ViewBag.Archivo = "Archivo no Valido";
                    return Redirect("Index");
                }

                var filen = (DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls").ToLower();
                //    var path = Server.MapPath("~/Files/entrada/" + filen);
                var path = Server.MapPath(@"~/Files/salida/" + filen);
                archivo.SaveAs(path);

                //Listadetalle = new List<DetalleOperacionesViewModel>();
                var hoja = new LeeExcel();
            var listadetalle = hoja.Excelnpoi(path);

          

                System.IO.File.Delete(path);
               //model.Doperaciones.AddRange(listadetalle);
               model.Doperaciones= new List<DetalleOperacionesViewModel>(); 
                foreach (var item in listadetalle)
                {
                    var dope = new DetalleOperacionesViewModel
                    {
                        RutDeudor = item.RutDeudor,
                        RutDeudorClass  = "@class='classalerta'",
                        NroDocumento = item.NroDocumento,
                        Monto = item.Monto,
                        FechaEmision = item.FechaEmision,
                        FechaVencimeinto = item.FechaVencimeinto,
                        Ciudad = item.Ciudad,
                        Direccion = item.Direccion,
                        Plaza = item.Plaza,
                        Pais = item.Pais,
                        Nombre = item.Nombre,
                        NroOperacio = item.NroOperacio,
                        Rutcliente = item.Rutcliente,
                       
                        
                    };
                    model.Doperaciones.Add(dope);
                   }
                   model.Opercion.MontoRemesa= model.Doperaciones.Sum(x => x.Monto);
                   model.Opercion.Ndeudores = model.Doperaciones.DistinctBy(x => x.RutDeudor).Count();
                   model.Opercion.TotalDoc = model.Doperaciones.Count;
                   model.Opercion.TotalAcum = model.Doperaciones.Sum(x => x.Monto);
            return View(model);

                }
    






        public ActionResult Listaoperaciones(int? id)
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
            var searchResults = new List<SelectListItem>();
            var searchResultsdatos = new List<Datos>();
            try
            {
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization",
                    ConfigurationManager.AppSettings["Token-AuthorizationOPE"]);
                var json = await cliente.GetStringAsync(
                    "http://10.250.13.245:8080/WS_FactoringCargaMasiva/ConsultarDatosOperacion/" + tipo);
                var desjson = JObject.Parse(json);
                IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoDatosOperacion"].Children().ToList();
                foreach (var result in results)
                {
                    var searchResult = result.ToObject<Datos>();
                    searchResultsdatos.Add(searchResult);
                }
                foreach (var item in searchResultsdatos)
                {
                    var items = new SelectListItem();

                    items.Text = item.Glosa.Trim();
                    items.Value = item.Id.ToString();
                    searchResults.Add(items);
                }

            }
            catch (Exception)
            {

                var searchResult = new Datos();
                searchResultsdatos.Add(searchResult);
            }

            return searchResults;
        }


        [HttpPost]
        //public RedirectResult Subir(HttpPostedFileBase file)
        //{
        //    if (file == null || file.ContentLength <= 0) return Redirect("Index");

        //    string archivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + file.FileName).ToLower();

        //    file.SaveAs(Server.MapPath("~/Uploads/" + archivo));
        //    return Redirect(LlenaTabla(Server.MapPath("~/Uploads/" + archivo)));
        //}

        public JsonResult BuscarClienterut(string term)
        {
            var cliente = new Cliente();

            var respuesta = cliente.ConsultaClienteBac(0, term);

            return Json(respuesta.Result.Cliente, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        //public RedirectResult Cargar(HttpPostedFileBase archivo)
        //{
        //    if (archivo == null || archivo.ContentLength <= 0) return Redirect("Index");
        //    var nombreArchivo = Path.GetFileName(archivo.FileName);
        //    var path = Path.Combine(Server.MapPath("~/Files/entrada"), nombreArchivo);
        //    archivo.SaveAs(path);
        //    return Redirect(LlenaTabla(archivo));
        //}
        

        public List<DetalleOperacionesViewModel> LlenaTabla(string archivo)
        {
            var Listadetalle = new List<DetalleOperacionesViewModel>();
            var detalle = new DetalleOperacionesViewModel();

            var hoja = new  LeeExcel();


            return Listadetalle;
        }


    }
}

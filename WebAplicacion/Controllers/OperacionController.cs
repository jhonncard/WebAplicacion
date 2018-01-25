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
using NPOI.OpenXmlFormats.Wordprocessing;
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
            var cons3 = new ConsultarDatosComunes3();
            modelo.Opercion.Guardar = "N";
            var tipooeracion = await LlamarServicios(1);
            var responsabilidad = await LlamarServicios(2);
            var cobranza = await LlamarServicios(3);
            var seguro = await LlamarServicios(4);
            var empresas = await cofgf.Empresas();
            var codigomoneda = await cofgf.Monedas();
            var tiopodoc = await cofgf.Documentos();
            var listasinoope = ope.LIstaSiNo();
            //var art84 = await cons3.AumentoArt84()
            tiopodoc[0].Selected = true;
            codigomoneda[2].Selected = true;




            ViewBag.tipooeracion = tipooeracion;
            ViewBag.responsabilidad = responsabilidad;
            ViewBag.cobranza = cobranza;
            ViewBag.seguro = seguro;
            ViewBag.empresas = empresas;
            ViewBag.fechaoperacion = await cofgf.FechaProceso(); ;
            ViewBag.codigomoneda = codigomoneda;
            ViewBag.tiopodoc = tiopodoc;
            ViewBag.listasino = listasinoope;

         
            return View(modelo);
        }

     


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
        public async Task<ActionResult> Index(  ListCargaMasivaViewModels model , HttpPostedFileBase archivo, string valorExtra)
        {
            if (valorExtra == "N" )
            {
                ViewBag.mensajealerta = "";
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
                var cons3 = new ConsultarDatosComunes3();
                if (archivo == null || archivo.ContentLength <= 0) return Redirect("Index");
                if (!(archivo.FileName.EndsWith("xls")))

                {
                    ViewBag.Archivo = "Archivo no Valido";
                    return View(model);
                }
                var filen = (DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls").ToLower();
                var path = Server.MapPath(@"~/Files/salida/" + filen);
                archivo.SaveAs(path);
                var hoja = new LeeExcel();
                var listadetalle = hoja.Excelnpoi(path);
                System.IO.File.Delete(path);
                model.Doperaciones = new List<DetalleOperacionesViewModel>();

                foreach (var item in listadetalle)
                {
                    var dope = new DetalleOperacionesViewModel
                    {
                        RutDeudor = item.RutDeudor,
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
                //ValidarDocumentos(model.Doperaciones);
                model.Opercion.MontoRemesa = model.Doperaciones.Sum(x => x.Monto);
                model.Opercion.Ndeudores = model.Doperaciones.DistinctBy(x => x.RutDeudor).Count();
                model.Opercion.TotalDoc = model.Doperaciones.Count;
                model.Opercion.TotalAcum = model.Doperaciones.Sum(x => x.Monto);







                return View(model);
             }
            else
            {
                //var grabar = new Grabar();
                //if (grabar.GrabaSimulacion(model))
                //    RedirectToAction("Index");
                //{
                //    model.Opercion.Guardar = "N";
                return View(model);
                //}
            }
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
                    ConfigurationManager.AppSettings["servicioBase"] +"/WS_FactoringCargaMasiva/ConsultarDatosOperacion/" + tipo);
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

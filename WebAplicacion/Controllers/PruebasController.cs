using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using WebAplicacion.Controllers.Servicios;
using WebAplicacion.Models.Operaciones;

namespace WebAplicacion.Controllers
{
    public class PruebasController : Controller
    {
        // GET: pruebas
        public ActionResult Index()
        {
            return View();
        }

        // GET: pruebas/Details/5
       

       


        public FileResult Descargar()
        {
            var ruta = Server.MapPath(@"~/Files/salida/cargaMasivo.xls");
            return File(ruta, "application/xls", "cargaMasivo.xls");
        }





        [HttpPost]
        public ActionResult Update(HttpPostedFileBase archivo)
        {
            if (archivo == null || archivo.ContentLength <= 0) return Redirect("Index");
            if (!(archivo.FileName.EndsWith("xls")))
            {
                ViewBag.Archivo= "archivo no valido";
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
           return View(listadetalle);

        }

        //public RedirectResult Cargar(HttpPostedFileBase archivo)
        //{
        //    if (archivo == null || archivo.ContentLength <= 0) return Redirect("Index");
        //    var nombreArchivo = Path.GetFileName(archivo.FileName);
        //    var path = Path.Combine(Server.MapPath("~/Files/entrada"), nombreArchivo);
        //    archivo.SaveAs(path);
        //    return Redirect(LlenaTabla(archivo));
        //}


       

    }
}


using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Web.Mvc;
using Factoring.Negocios;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.OpenXmlFormats.Dml;
using NPOI.SS.Formula.Functions;
using WebAplicacion.Controllers.Servicios;
using WebAplicacion.Models;
using WebAplicacion.Models.Clientes;

namespace WebAplicacion.Controllers
{
    public class ClientesController : Controller
    {
        private readonly Cliente _cliente = new Cliente();
        private MantClientesViewModel clienteold = new MantClientesViewModel();

        private readonly HttpClient cliente = new HttpClient();
        public ClientesController()
        {
            clienteold = new MantClientesViewModel();
        }

           [HttpGet]
        public async Task<ActionResult> Index()
           {
               var buscardatos = new Cliente();
               var politicas = await buscardatos.DefPoliticas();
               ViewBag.ValidacionPoliticas = politicas;
            return View();
        }


        public async Task<ActionResult> Buscarcliente(string id)
        {
            var buscardatos = new Cliente();
           
            var paramid = 0;
            try
            {
                long.Parse(id);
                paramid = 1;
            }
            catch (Exception)
            {
                paramid = 0;
            }
         
            
                return View("Index",await buscardatos.ConsultaClienteBac(paramid, id));
              
        }

        public async Task<ActionResult> BuscarDetalle(string rut)
           {
               var buscardatos = new Cliente();
                var politicas =await buscardatos.DefPoliticas();
               ViewBag.ValidacionPoliticas = politicas;

               return View("Index", buscardatos.ConsultaClienteFac(rut).Result.First());              
           }

        public async Task<ActionResult> GuardaResult(MantClientesViewModel modelo)
        {
            var buscardatos = new Cliente();
            var reflex = new Reflectiones();

               clienteold =  buscardatos.ConsultaClienteFac(modelo.Rut).Result.First();
               ViewBag.Mensaje = "Cambiso Guardados";
               if (await reflex.Comprar(clienteold, modelo, "user", "condiciones"))  
                    await   buscardatos.Guardar(modelo);
                 
                return View("Index", modelo );
           }

        //[HttpPost]
        //[AllowAnonymous]
        public async  Task<JsonResult> GetClientePorNombre(string nombre)
        {
           var obtener = new Cliente();
           var elcliente = await obtener.GetClienteNombre(0, nombre);
            return Json(elcliente[0], JsonRequestBehavior.AllowGet);
            //return Json(elcliente[0].Rut


            //new
            //{
            //    Success = true,
            //    Clientes = "jhonny"
            //},
            //JsonRequestBehavior.AllowGet
            //);
        }


        public async Task<JsonResult> GetClientePorRut(string nombre)
        {   var obtener = new Cliente();
            var elcliente = await obtener.GetClienteNombre(1, nombre);
            return Json(elcliente, JsonRequestBehavior.AllowGet);
            //return Json(elcliente[0].Rut


            //new
            //{
            //    Success = true,
            //    Clientes = "jhonny"
            //},
            //JsonRequestBehavior.AllowGet
            //);
        }
        public async Task<JsonResult> GetClientesPorRut(string term)
        {
            var obtener = new Cliente();
            var clientes = await obtener.GetClienteNombre(1, term);
            var lclientes = clientes.Select(item => item.Rut).Take(int.Parse(ConfigurationManager.AppSettings["LargoLista"])).ToList();
            return Json(lclientes, JsonRequestBehavior.AllowGet);
           }


        public async Task<JsonResult> GetClientesPorNombre(string term)
       {
            var obtener = new Cliente();
            var clientes = await obtener.GetClienteNombre(0, term);
            var lclientes = clientes.Select(item => item.Cliente).Take(int.Parse(ConfigurationManager.AppSettings["LargoLista"])).ToList();
            return  Json(lclientes,JsonRequestBehavior.AllowGet);
        }


        public async Task<JsonResult> GetClienteDatosFinacieros(string rut, int tipodoc,int tipomond)
        {
            var obtener = new DatFinancieros();
            var datfinacieros = await obtener.DatosFinancieros(rut, tipodoc,tipomond) ;
            return Json(datfinacieros, JsonRequestBehavior.AllowGet);
        }




         




















    }

}

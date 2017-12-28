
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
using WebAplicacion.Controllers.Servicios;
using WebAplicacion.Models;

namespace WebAplicacion.Controllers
{
    public class ClientesController : Controller
    {
        private readonly Cliente _cliente = new Cliente();
        private Mant_ClientesViewModel clienteold = new Mant_ClientesViewModel();

        private readonly HttpClient cliente = new HttpClient();
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
         
            
                return View("Index", buscardatos.ConsultaClienteBac(paramid, id).Result);
              
        }

        public async Task<ActionResult> BuscarDetalle(string rut)
           {
               var buscardatos = new Cliente();
               return View("Index", buscardatos.ConsultaClienteFac(rut).Result.First());
               
           }




        public async Task<ActionResult> GuardaResult(Mant_ClientesViewModel modelo)
        {
            var buscardatos = new Cliente();
            var reflex = new Reflectiones();

               clienteold =  buscardatos.ConsultaClienteFac(modelo.Rut).Result.First();
               ViewBag.Mensaje = "Cambiso Guardados";
               if (await reflex.Comprar(clienteold, modelo, "user", "condiciones"))  
                    await   buscardatos.Guardar(modelo);
                 
                return View("Index", modelo );
           }

     

        [HttpPost]
        [AllowAnonymous]
        public async  Task<JsonResult> GetClientePorNombre(string nombre)
        {
           var obtener = new Cliente();

              return Json( new
                    {   Success = true,
                        Clientes =await obtener.GetClienteNombre(0, nombre)
                    },
                    JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetClientePorRut(string nombre )
        {
            var obtener = new Cliente();

            return Json(new
                {
                    Success = true,
                    Clientes = await obtener.GetClienteNombre(1, nombre)
                },
                JsonRequestBehavior.AllowGet);
            
            }
    }
}

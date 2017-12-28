using WebAplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

using WebAplicacion.Controllers.Servicios;


namespace WebAplicacion.Controllers
{
    public class DeudoresController : Controller
    {
        private Mant_DuedoresViewModel DeudorOld = new Mant_DuedoresViewModel();

        private readonly HttpClient _cliente = new HttpClient();


        public ActionResult Index()
        {
           return  RedirectToAction("BuscarDetalle", "Deudores");
           // return View();
        }

        public ActionResult Buscardeudor(string id)
        {
            var buscardatos = new Deudor();

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


            return View("Index", buscardatos.ConsultarDeudor(paramid, id).Result.First());

        }


        public async Task<ActionResult> BuscarDetalle(string rut)
        {
            var buscardatos = new Deudor();
           

            return View("Index", await buscardatos.ConsultarDeudorFac(rut));

         }


        public async Task<ActionResult> GuardaResult(Mant_DuedoresViewModel modelo)
        {
            var buscardatos = new Deudor();
          await  buscardatos.GuardarDeudor(modelo);

            return View("Index", modelo);

        }
        
        public async Task<JsonResult> GetDeudorPorNombre( string nombre)
        {
            var buscardatos = new Deudor();
            
            return Json(new
            {
                Success = true,
                Clientes = await buscardatos.GetDeudorPorNombre(0, nombre)
            },
                JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetDeudorePorRut(string nombre)
        {
            var buscardatos = new Deudor();

            return Json(new
                {
                    Success = true,
                    Clientes = await  buscardatos.GetDeudorPorNombre(1, nombre)
                },
                JsonRequestBehavior.AllowGet);
        }
    }

  }

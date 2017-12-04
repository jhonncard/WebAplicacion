using WebAplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


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
        public async Task<ActionResult> Details(int id)
        {
            var httpcliente = new HttpClient();
         var json=await   httpcliente.GetStringAsync("urldel servicio");
         // var lista = JsonHelper.JsonDeserialize(json)  List<LoggersViewModel> 
            return View();
        }

      
    }
}

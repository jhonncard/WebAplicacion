using WebAplicacion.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace WebAplicacion.Controllers
{
    public class CondicionesController : Controller
    {
        // GET: FactoringPyme/Condiciones
        public async Task<ActionResult> Index()
        {
            IList<CondicionesFactoringViewModel> searchResults = new List<CondicionesFactoringViewModel>();

            //try
            //{
            //    var cliente = new HttpClient();
            //    cliente.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            //    cliente.DefaultRequestHeaders.TryAddWithoutValidation("Token-Authorization", "YXBwdG9vbGJveDphcHB0b29sYm94QHRlbGVmb25pY2EuY29t");
            //    var json = await cliente.GetStringAsync("http://10.250.13.245:8080/WS_FactoringMCC/ConsultarCondicionesComerciales" );
            //    JObject desjson = JObject.Parse(json);
            //    IList<JToken> results = desjson["dtoResponseSetResultados"]["dtoCondicionesComerciales"].Children().ToList();
            //    foreach (JToken result in results)
            //    {
            //        CondicionesFactoringViewModel searchResult = result.ToObject<CondicionesFactoringViewModel>();
            //        searchResults.Add(searchResult);
            //    }
            //}
            //catch (Exception ex)
            //{

            //    throw ex ;
            //}

            //return View(searchResults.First());
            return View();
        }

        [HttpPost]
       
        public ActionResult Details(CondicionesFactoringViewModel modelo)
        {
            //HttpClient cliente = new HttpClient();
            //cliente.GetAsync()
            return View();
        }

        // GET: FactoringPyme/Condiciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FactoringPyme/Condiciones/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FactoringPyme/Condiciones/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FactoringPyme/Condiciones/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FactoringPyme/Condiciones/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FactoringPyme/Condiciones/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

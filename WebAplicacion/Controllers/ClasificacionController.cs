using System.Web.Mvc;
using WebAplicacion.Models;

namespace WebAplicacion.Controllers
{
    public class ClasificacionController : Controller
    {
        // GET: FactoringPyme/Clasificacion
        public ActionResult Index()
        {
            return View();
        }

        // GET: FactoringPyme/Clasificacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FactoringPyme/Clasificacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FactoringPyme/Clasificacion/Create
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

        // GET: FactoringPyme/Clasificacion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FactoringPyme/Clasificacion/Edit/5
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

        // GET: FactoringPyme/Clasificacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FactoringPyme/Clasificacion/Delete/5
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

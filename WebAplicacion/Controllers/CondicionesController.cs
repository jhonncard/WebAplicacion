using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAplicacion.Controllers
{
    public class CondicionesController : Controller
    {
        // GET: FactoringPyme/Condiciones
        public ActionResult Index()
        {
            return View();
        }

        // GET: FactoringPyme/Condiciones/Details/5
        public ActionResult Details(int id)
        {
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

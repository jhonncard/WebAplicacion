using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAplicacion.Controllers
{
    public class BacFactoringController : Controller
    {
        // GET: BacFactoring
        public ActionResult Index()
        {
            return View();
        }

        // GET: BacFactoring/Details/5
        public ActionResult DetailsOperacion(string rut)
        {
            return View();
        }

        // GET: BacFactoring/Details/5
        public ActionResult DetailsFacturas(FileStream archivoexcel)
        {
            return View();
        }

        // GET: BacFactoring/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BacFactoring/Create
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

        // GET: BacFactoring/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BacFactoring/Edit/5
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

        // GET: BacFactoring/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BacFactoring/Delete/5
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAplicacion.Controllers
{
    public class OperacionController : Controller
    {
        // GET: Factoring/Operacion
        public ActionResult Index()
        {
            return View();
        }

        // GET: Factoring/Operacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Factoring/Operacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Factoring/Operacion/Create
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

        // GET: Factoring/Operacion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Factoring/Operacion/Edit/5
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

        // GET: Factoring/Operacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Factoring/Operacion/Delete/5
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

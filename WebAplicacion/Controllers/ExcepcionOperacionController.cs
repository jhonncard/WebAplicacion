using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAplicacion.Controllers
{
    public class ExcepcionOperacionController : Controller
    {
        // GET: ExcepcionOperacion
        public ActionResult Index()
        {
            return View();
        }

        // GET: ExcepcionOperacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExcepcionOperacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExcepcionOperacion/Create
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

        // GET: ExcepcionOperacion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExcepcionOperacion/Edit/5
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

        // GET: ExcepcionOperacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExcepcionOperacion/Delete/5
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

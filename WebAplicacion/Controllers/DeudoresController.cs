﻿using System.Web.Mvc;

namespace WebAplicacion.Controllers
{
    public class DeudoresController : Controller
    {
        // GET: FactoringPyme/Deudores
        public ActionResult Index()
        {
            return View();
        }

        // GET: FactoringPyme/Deudores/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FactoringPyme/Deudores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FactoringPyme/Deudores/Create
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

        // GET: FactoringPyme/Deudores/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FactoringPyme/Deudores/Edit/5
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

        // GET: FactoringPyme/Deudores/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FactoringPyme/Deudores/Delete/5
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

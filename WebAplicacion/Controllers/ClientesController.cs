
using System.Web.Mvc;
using WebAplicacion.Models;

namespace WebAplicacion.Controllers
{
    public class ClientesController : Controller
       {
        private Mant_ClientesViewModel clienteold;

        public ClientesController()
        {
            clienteold = new Mant_ClientesViewModel();
        }


        public ActionResult Index()
        {
            return View();
        }

        // GET: FactoringPyme/Clientes_Man_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FactoringPyme/Clientes_Man_/Create
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

        // GET: FactoringPyme/Clientes_Man_/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FactoringPyme/Clientes_Man_/Edit/5
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

        // GET: FactoringPyme/Clientes_Man_/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FactoringPyme/Clientes_Man_/Delete/5
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

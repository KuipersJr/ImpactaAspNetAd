using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Mvc.Controllers
{
    public class TransportadoraController : Controller
    {
        // GET: Transportadora
        public ActionResult Index()
        {
            return View();
        }

        // GET: Transportadora/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Transportadora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transportadora/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                //throw new Exception("Teste");

                return RedirectToAction("Index");
            }
            catch(Exception excecao)
            {
                //ModelState.AddModelError(string.Empty, excecao.Message);
                return View();
            }
        }

        // GET: Transportadora/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Transportadora/Edit/5
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

        // GET: Transportadora/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Transportadora/Delete/5
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

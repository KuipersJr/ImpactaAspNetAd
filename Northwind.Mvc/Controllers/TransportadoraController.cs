using Northwind.Dominio;
using NorthWind.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Mvc.Controllers
{
    public class TransportadoraController : Controller
    {
        TransportadoraRepositorio _transportadoraRepositorio = new TransportadoraRepositorio();

        // GET: Transportadora
        public ActionResult Index()
        {
            var transportadoras = _transportadoraRepositorio.Selecionar();

            return View(transportadoras);
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
                var transportadora = new Transportadora();
                transportadora.Nome = collection["Nome"];
                transportadora.Telefone = collection["Telefone"];

                new TransportadoraRepositorio().Inserir(transportadora);

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
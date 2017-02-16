using Impacta.Apoio;
using Northwind.Dominio;
using NorthWind.Repositorios.SqlServer;
using System;
using System.Web.Mvc;

namespace Northwind.Mvc.Controllers
{
    public class TransportadoraController : Controller
    {
        TransportadoraRepositorio _transportadoraRepositorio = new TransportadoraRepositorio();

        // GET: Transportadora
        public ActionResult Index()
        {
            return View(_transportadoraRepositorio.Selecionar());
        }

        // GET: Transportadora/Details/5
        public ActionResult Details(int id)
        {
            return View(_transportadoraRepositorio.Selecionar(id));
        }

        // GET: Transportadora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transportadora/Create
        [HttpPost]
        public ActionResult Create(Transportadora transportadora)
        {
            try
            {
                //var transportadora = new Transportadora();
                //transportadora.Nome = collection["Nome"];
                //transportadora.Telefone = collection["Telefone"];

                _transportadoraRepositorio.Inserir(transportadora);

                //throw new Exception("Teste");

                return RedirectToAction("Index");
            }
            catch (Exception excecao)
            {
                //ModelState.AddModelError(string.Empty, excecao.Message);
                return View();
            }
        }

        // GET: Transportadora/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_transportadoraRepositorio.Selecionar(id));
        }

        // POST: Transportadora/Edit/5
        [HttpPost]
        public ActionResult Edit(Transportadora transportadora)
        {
            try
            {
                Validar.DataAnnotations(transportadora);

                _transportadoraRepositorio.Atualizar(transportadora);

                return RedirectToAction("Index");
            }
            catch (DataAnnotationValidationException excecao)
            {
                foreach (var erro in excecao.ErrosValidacao)
                {
                    ModelState.AddModelError(string.Empty, erro.ErrorMessage);
                }

                return View();
            }
        }

        // GET: Transportadora/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_transportadoraRepositorio.Selecionar(id));
        }

        // POST: Transportadora/Delete/5
        [HttpPost]
        public ActionResult Delete(Transportadora transportadora)
        {
            try
            {
                _transportadoraRepositorio.Excluir(transportadora.Id);

                return RedirectToAction("Index");
            }
            catch (Exception excecao)
            {
                //ModelState.AddModelError(string.Empty, excecao.Message);

                return View();
            }
        }
    }
}
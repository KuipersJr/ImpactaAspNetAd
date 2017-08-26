using Northwind.Mvc.Ado.ViewModels;
using NorthWind.Repositorios.SqlServer;
using System.Web.Mvc;
using Northwind.Dominio;
using System.Collections.Generic;

namespace Northwind.Mvc.Ado.Controllers
{
    public class TransportadoraController : Controller
    {
        TransportadoraRepositorio _transportadoraRepositorio = new TransportadoraRepositorio();

        // GET: Transportadora
        public ActionResult Index()
        {
            return View(Mapear(_transportadoraRepositorio.Selecionar()));
        }

        private List<TransportadoraViewModel> Mapear(List<Transportadora> transportadoras)
        {
            var transportadorasViewModel = new List<TransportadoraViewModel>();

            foreach (var transportadora in transportadoras)
            {
                transportadorasViewModel.Add(Mapear(transportadora));
            }

            return transportadorasViewModel;
        }

        // GET: Transportadora/Details/5
        public ActionResult Details(int id)
        {
            return View(Mapear(_transportadoraRepositorio.Selecionar(id)));
        }

        private TransportadoraViewModel Mapear(Transportadora transportadora)
        {
            return new TransportadoraViewModel
            {
                Id = transportadora.Id,
                Nome = transportadora.Nome,
                Telefone = transportadora.Telefone
            };
        }

        // GET: Transportadora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transportadora/Create
        [HttpPost]
        public ActionResult Create(TransportadoraViewModel viewModel)
        {
            try
            {
                //var transportadora = new Transportadora();
                //transportadora.Nome = collection["Nome"];
                //transportadora.Telefone = collection["Telefone"];

                _transportadoraRepositorio.Inserir(Mapear(viewModel));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private Transportadora Mapear(TransportadoraViewModel viewModel)
        {
            return new Transportadora
            {
                Id = viewModel.Id,
                Nome = viewModel.Nome,
                Telefone = viewModel.Telefone
            };
        }

        // GET: Transportadora/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Mapear(_transportadoraRepositorio.Selecionar(id)));
        }

        // POST: Transportadora/Edit/5
        [HttpPost]
        public ActionResult Edit(TransportadoraViewModel transportadora)
        {
            try
            {
                _transportadoraRepositorio.Atualizar(Mapear(transportadora));

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
            return View(Mapear(_transportadoraRepositorio.Selecionar(id)));
        }

        // POST: Transportadora/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TransportadoraViewModel transportadora)
        {
            try
            {
                _transportadoraRepositorio.Excluir(transportadora.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
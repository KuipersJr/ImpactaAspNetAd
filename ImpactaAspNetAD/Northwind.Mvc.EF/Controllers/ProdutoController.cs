using System.Linq;
using System.Net;
using System.Web.Mvc;
using Loja.Dominio;
using Loja.Mvc.Models;
using System.Web;
using System.IO;
using System.Collections.Generic;
using Loja.Repositorios.SqlServer.EF;
using Loja.Mvc.Helpers;

namespace Loja.Mvc.EF.Controllers
{
    public class ProdutoController : Controller
    {
        private LojaDbContext db = new LojaDbContext();

        // GET: Produto
        public ActionResult Index()
        {
            return View(Mapeamento.Mapear(db.Produtos.ToList()));
        }

        [ActionName("ProdutosPorCategoria")]
        public ActionResult Index(int categoriaId)
        {
            return View("Index", db.Produtos.Where(p => p.Categoria.Id == categoriaId).OrderBy(p => p.Nome).ToList());
        }

        // GET: Produto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Produto produto = db.Produtos.Find(id);

            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(Mapeamento.Mapear(produto));
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View(Mapeamento.Mapear(new Produto(), db.Categorias.ToList()));
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel viewModel/*, HttpPostedFileBase imagemProduto*/)
        {
            if (viewModel.Imagem != null && !Produto.ValidarFormatoImagem(viewModel.Imagem.ContentType))
            {
                ModelState.AddModelError("imagemProduto", "Apenas arquivos de imagem são permitidos.");
            }

            var produto = Mapeamento.Mapear(viewModel, db/*, viewModel.Imagem*/);

            if (ModelState.IsValid)
            {
                db.Produtos.Add(produto);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(Mapeamento.Mapear(produto, db.Categorias.ToList()));
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var produto = db.Produtos.Find(id);

            if (produto == null)
            {
                return HttpNotFound();
            }

            //return View(new ProdutoViewModel(db.Categorias.ToList(), produto));
            return View(Mapeamento.Mapear(produto, db.Categorias.ToList()));
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel viewModel/*, HttpPostedFileBase imagemProduto*/)
        {
            var produto = db.Produtos.Find(viewModel.Id);

            Mapeamento.Mapear(viewModel, produto, db/*, imagemProduto*/);

            if (viewModel.Imagem != null && !Produto.ValidarFormatoImagem(viewModel.Imagem.ContentType))
            {
                ModelState.AddModelError("imagemProduto", "Apenas arquivos de imagem são permitidos.");
            }

            if (ModelState.IsValid)
            {
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            //return View(new ProdutoViewModel(db.Categorias.ToList(), produto));
            return View(Mapeamento.Mapear(produto, db.Categorias.ToList()));
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Produto produto = db.Produtos.Find(id);

            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(Mapeamento.Mapear(produto));
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
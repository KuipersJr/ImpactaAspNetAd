using System.Linq;
using System.Net;
using System.Web.Mvc;
using Loja.Dominio;
using Loja.Mvc.Helpers;
using Loja.Mvc.Models;
using Loja.Repositorios.SqlServer.EF;

namespace Loja.Mvc.Controllers
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

        public ActionResult Create()
        {
            return View(Mapeamento.Mapear(new Produto(), db.Categorias.ToList()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel viewModel)
        {
            if (viewModel.Imagem != null && !Produto.ValidarFormatoImagem(viewModel.Imagem.ContentType))
            {
                ModelState.AddModelError("imagemProduto", "Apenas arquivos de imagem são permitidos.");
            }

            var produto = Mapeamento.Mapear(viewModel, db);

            if (ModelState.IsValid)
            {
                db.Produtos.Add(produto);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(Mapeamento.Mapear(produto, db.Categorias.ToList()));
        }

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

            return View(Mapeamento.Mapear(produto, db.Categorias.ToList()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel viewModel)
        {
            var produto = db.Produtos.Find(viewModel.Id);

            Mapeamento.Mapear(viewModel, produto, db);

            if (viewModel.Imagem != null && !Produto.ValidarFormatoImagem(viewModel.Imagem.ContentType))
            {
                ModelState.AddModelError("imagemProduto", "Apenas arquivos de imagem são permitidos.");
            }

            if (ModelState.IsValid)
            {
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            
            return View(Mapeamento.Mapear(produto, db.Categorias.ToList()));
        }

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
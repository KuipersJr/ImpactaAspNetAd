using System.Linq;
using System.Net;
using System.Web.Mvc;
using NorthWind.Repositorios.SqlServer.EF;
using Northwind.Dominio;
using Northwind.Mvc.EF.ViewModels;
using System.Web;
using System.IO;

namespace Northwind.Mvc.EF.Controllers
{
    public class ProdutoController : Controller
    {
        private LojaDbContext db = new LojaDbContext();

        // GET: Produto
        public ActionResult Index()
        {
            return View(db.Produtos.OrderBy(p => p.Nome).ToList());
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
            return View(produto);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View(new ProdutoViewModel(db.Categorias.ToList()));
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto, HttpPostedFileBase imagemProduto)
        {
            if (imagemProduto != null && !produto.ValidarFormatoImagem(imagemProduto.ContentType))
            {
                ModelState.AddModelError("imagemProduto", "Apenas arquivos de imagem são permitidos.");            
            }

            if (ModelState.IsValid)
            {
                if (imagemProduto != null && imagemProduto.ContentLength > 0)
                {
                    using (var reader = new BinaryReader(imagemProduto.InputStream))
                    {
                        produto.Imagem = new ProdutoImagem { Bytes = reader.ReadBytes(imagemProduto.ContentLength), ContentType = imagemProduto.ContentType };
                    }
                }

                produto.Categoria = db.Categorias.Find(produto.Categoria.Id);

                db.Produtos.Add(produto);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(new ProdutoViewModel(db.Categorias.ToList(), produto));
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

            return View(new ProdutoViewModel(db.Categorias.ToList(), produto));
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produto produto, HttpPostedFileBase imagemProduto)
        {
            var produtoBanco = db.Produtos.Find(produto.Id);

            if (imagemProduto != null && !produto.ValidarFormatoImagem(imagemProduto.ContentType))
            {
                ModelState.AddModelError("imagemProduto", "Apenas arquivos de imagem são permitidos.");
                produto.Imagem = produtoBanco.Imagem;
            }

            if (ModelState.IsValid)
            {
                db.Entry(produtoBanco).CurrentValues.SetValues(produto);

                produtoBanco.Categoria = db.Categorias.Single(c => c.Id == produto.Categoria.Id);

                if (imagemProduto != null && imagemProduto.ContentLength > 0)
                {
                    using (var reader = new BinaryReader(imagemProduto.InputStream))
                    {
                        if (produtoBanco.Imagem == null)
                        {
                            produtoBanco.Imagem = new ProdutoImagem { Bytes = reader.ReadBytes(imagemProduto.ContentLength), ContentType = imagemProduto.ContentType };
                        }
                        else
                        {
                            produtoBanco.Imagem.Bytes = reader.ReadBytes(imagemProduto.ContentLength);
                            produtoBanco.Imagem.ContentType = imagemProduto.ContentType;
                        }
                    }
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(new ProdutoViewModel(db.Categorias.ToList(), produto));
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
            return View(produto);
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
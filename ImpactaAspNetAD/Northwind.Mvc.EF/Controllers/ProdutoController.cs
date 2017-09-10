using System.Linq;
using System.Net;
using System.Web.Mvc;
using NorthWind.Repositorios.SqlServer.EF;
using Northwind.Dominio;
using Northwind.Mvc.EF.ViewModels;
using System.Web;
using System.IO;
using System;
using System.Collections.Generic;

namespace Northwind.Mvc.EF.Controllers
{
    public class ProdutoController : Controller
    {
        private LojaDbContext db = new LojaDbContext();

        // GET: Produto
        public ActionResult Index()
        {
            var produtosViewModel = new List<ProdutoViewModel>();

            foreach (var produto in db.Produtos.ToList())
            {
                produtosViewModel.Add(Mapear(produto));
            }

            return View(produtosViewModel);
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
            return View(Mapear(new Produto(), db.Categorias.ToList()));
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel viewModel, HttpPostedFileBase imagemProduto)
        {
            if (imagemProduto != null && !Produto.ValidarFormatoImagem(imagemProduto.ContentType))
            {
                ModelState.AddModelError("imagemProduto", "Apenas arquivos de imagem são permitidos.");
            }

            var produto = Mapear(viewModel, imagemProduto);

            if (ModelState.IsValid)
            {
                db.Produtos.Add(produto);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(Mapear(produto, db.Categorias.ToList()));
        }

        // ToDo: implementar Automapper.
        private Produto Mapear(ProdutoViewModel viewModel, HttpPostedFileBase imagemProduto)
        {
            var produto = new Produto();

            if (imagemProduto != null && imagemProduto.ContentLength > 0)
            {
                using (var reader = new BinaryReader(imagemProduto.InputStream))
                {
                    produto.Imagem = new ProdutoImagem
                    {
                        Bytes = reader.ReadBytes(imagemProduto.ContentLength),
                        ContentType = imagemProduto.ContentType
                    };
                }
            }

            produto.Categoria = db.Categorias.Find(viewModel.CategoriaId);
            produto.Descontinuado = viewModel.Descontinuado;
            produto.Estoque = viewModel.Estoque.Value;
            produto.Nome = viewModel.Nome;
            produto.Preco = viewModel.Preco.Value;

            return produto;
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
            return View(Mapear(produto, db.Categorias.ToList()));
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel viewModel, HttpPostedFileBase imagemProduto)
        {
            var produto = db.Produtos.Find(viewModel.Id);

            Mapear(viewModel, produto, imagemProduto);

            if (imagemProduto != null && !Produto.ValidarFormatoImagem(imagemProduto.ContentType))
            {
                ModelState.AddModelError("imagemProduto", "Apenas arquivos de imagem são permitidos.");
            }

            if (ModelState.IsValid)
            {
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            //return View(new ProdutoViewModel(db.Categorias.ToList(), produto));
            return View(Mapear(produto, db.Categorias.ToList()));
        }

        private void Mapear(ProdutoViewModel viewModel, Produto produto, HttpPostedFileBase imagemProduto)
        {
            db.Entry(produto).CurrentValues.SetValues(viewModel);

            produto.Categoria = db.Categorias.Single(c => c.Id == viewModel.CategoriaId);

            if (imagemProduto != null && imagemProduto.ContentLength > 0)
            {
                using (var reader = new BinaryReader(imagemProduto.InputStream))
                {
                    if (produto.Imagem == null)
                    {
                        produto.Imagem = new ProdutoImagem
                        {
                            Bytes = reader.ReadBytes(imagemProduto.ContentLength),
                            ContentType = imagemProduto.ContentType
                        };
                    }
                    else
                    {
                        produto.Imagem.Bytes = reader.ReadBytes(imagemProduto.ContentLength);
                        produto.Imagem.ContentType = imagemProduto.ContentType;
                    }
                }
            }
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

        private ProdutoViewModel Mapear(Produto produto, List<Categoria> categorias = null)
        {
            var viewModel = new ProdutoViewModel();

            viewModel.CategoriaId = produto.Categoria?.Id;
            viewModel.CategoriaNome = produto.Categoria?.Nome;

            if (categorias != null)
            {
                foreach (var categoria in categorias)
                {
                    viewModel.Categorias.Add(new SelectListItem { Text = categoria.Nome, Value = categoria.Id.ToString() });
                }
            }

            viewModel.Estoque = produto.Estoque;
            viewModel.Id = produto.Id;
            viewModel.Nome = produto.Nome;
            viewModel.Preco = produto.Preco;

            return viewModel;
        }

    }
}
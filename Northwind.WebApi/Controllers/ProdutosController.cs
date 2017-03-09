using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using NorthWind.Repositorios.SqlServer.EF.ModelFirst;
using System.Web.Http.Cors;
using Northwind.WebApi.ViewModels;
using System.Collections.Generic;

namespace Northwind.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProdutosController : ApiController
    {
        private NorthwindContainer db = new NorthwindContainer();

        // GET: api/Produtos
        public IQueryable<Produto> GetProdutos()
        {
            return db.Produto;
        }

        // GET: api/Produtos/5
        //[ResponseType(typeof(Produto))]
        //public IHttpActionResult GetProduto(int id)
        //{
        //    Produto produto = db.Produto.Find(id);
        //    if (produto == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(produto);
        //}

        [ResponseType(typeof(ProdutoViewModel))]
        public IHttpActionResult GetProduto(int id)
        {
            var produto = db.Produto.Find(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(new ProdutoViewModel(produto));
        }

        [HttpGet]
        [ResponseType(typeof(List<ProdutoViewModel>))]
        public IHttpActionResult GetByName(string nome)
        {
            var produtos = db.Produto.Where(p => p.Nome.Contains(nome)).ToList();

            var produtosViewModel = new List<ProdutoViewModel>();

            produtos.ForEach(p => produtosViewModel.Add(new ProdutoViewModel(p)));

            return Ok(produtosViewModel);
        }

        // PUT: api/Produtos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduto(int id, Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produto.Id)
            {
                return BadRequest();
            }

            db.Entry(produto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Produtos
        [ResponseType(typeof(Produto))]
        public IHttpActionResult PostProduto(Produto produto)
        {
            if (produto == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            produto.Categoria = db.Categoria.Single(c => c.Id == produto.Categoria.Id);

            db.Produto.Add(produto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = produto.Id }, produto);
        }

        // DELETE: api/Produtos/5
        [ResponseType(typeof(Produto))]
        public IHttpActionResult DeleteProduto(int id)
        {
            Produto produto = db.Produto.Find(id);

            if (produto == null)
            {
                return NotFound();
            }

            db.Produto.Remove(produto);
            db.SaveChanges();

            return Ok(produto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProdutoExists(int id)
        {
            return db.Produto.Count(e => e.Id == id) > 0;
        }
    }
}
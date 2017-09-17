using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using NorthWind.Repositorios.SqlServer.EF.ModelFirst;
using Loja.WebApi.ViewModels;
using System.Web.Http.Cors;
using System.Collections.Generic;

namespace Loja.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CategoriasController : ApiController
    {
        private NorthwindContainer db = new NorthwindContainer();

        //public CategoriasController()
        //{
        //    db.Configuration.ProxyCreationEnabled = false;
        //}

        // GET: api/Categorias
        public IQueryable<Categoria> GetCategoria()
        {
            return db.Categoria;
        }

        // Mencionar a relação entre CRUD e os verbos do HTTP.

        //public IQueryable<CategoriaViewModel> Get()
        //{
        //    return db.Categoria.Select(c => new CategoriaViewModel { Id = c.Id, Nome = c.Nome });
        //}

        //public async Task<List<Categoria>> GetProdutos()
        //{
        //    return await db.Categoria.ToListAsync();
        //}

        // GET: api/Categorias/5
        [ResponseType(typeof(Categoria))]
        public async Task<IHttpActionResult> GetCategoria(int id)
        {
            Categoria categoria = await db.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        //public async Task<CategoriaViewModel> GetCategoria(int id)
        //{
        //    return await db.Categoria
        //        .Where(c => c.Id == id)
        //        .Select(c => new CategoriaViewModel { Id = c.Id, Nome = c.Nome })
        //        .SingleOrDefaultAsync();
        //}

        // PUT: api/Categorias/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoria.Id)
            {
                return BadRequest();
            }

            db.Entry(categoria).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
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

        // POST: api/Categorias
        [ResponseType(typeof(Categoria))]
        public async Task<IHttpActionResult> PostCategoria(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categoria.Add(categoria);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = categoria.Id }, categoria);
        }

        // DELETE: api/Categorias/5
        [ResponseType(typeof(Categoria))]
        public async Task<IHttpActionResult> DeleteCategoria(int id)
        {
            Categoria categoria = await db.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            db.Categoria.Remove(categoria);
            await db.SaveChangesAsync();

            return Ok(categoria);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoriaExists(int id)
        {
            return db.Categoria.Count(e => e.Id == id) > 0;
        }
    }
}
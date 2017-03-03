using Impacta.Apoio;
using NorthWind.Repositorios.SqlServer.EF;
using System.Linq;
using System.Web.Mvc;

namespace Northwind.Mvc.EF.Controllers
{
    public class ImagemController : Controller
    {
        LojaDbContext _contexto = new LojaDbContext();

        public ActionResult Index(int produtoId)
        {
            var produto = _contexto.Produtos.Single(p => p.Id == produtoId);

            return File(produto.Imagem.Bytes, produto.Imagem.ContentType);
        }

        public ActionResult Miniatura(int produtoId, int largura = 50, int altura = 50)
        {
            var produto = _contexto.Produtos.Single(p => p.Id == produtoId);

            return File(Imagem.ObterMiniatura(produto.Imagem.Bytes, largura, altura), produto.Imagem.ContentType);
        }

        protected override void Dispose(bool disposing)
        {
            _contexto.Dispose();

            base.Dispose(disposing);
        }
    }
}
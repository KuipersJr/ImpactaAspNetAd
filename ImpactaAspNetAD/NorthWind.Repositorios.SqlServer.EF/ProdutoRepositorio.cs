using Loja.Dominio;

namespace Loja.Repositorios.SqlServer.EF
{
    public class ProdutoRepositorio : RepositorioBase<Produto>
    {
        public ProdutoRepositorio(LojaDbContext _contexto) : base(_contexto)
        {
            
        }
    }
}
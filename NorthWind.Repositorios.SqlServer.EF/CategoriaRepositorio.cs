using Northwind.Dominio;

namespace NorthWind.Repositorios.SqlServer.EF
{
    public class CategoriaRepositorio : RepositorioBase<Categoria>
    {
        public CategoriaRepositorio(LojaDbContext _contexto) : base(_contexto)
        {

        }
    }
}
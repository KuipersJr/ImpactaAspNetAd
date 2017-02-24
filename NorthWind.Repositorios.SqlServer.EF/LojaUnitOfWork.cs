using System;

namespace NorthWind.Repositorios.SqlServer.EF
{
    public class LojaUnitOfWork : IDisposable
    {
        LojaDbContext _contexto = new LojaDbContext();

        public ProdutoRepositorio Produtos { get; set; }
        public CategoriaRepositorio Categorias { get; set; }

        public LojaUnitOfWork()
        {
            Produtos = new ProdutoRepositorio(_contexto);
            Categorias = new CategoriaRepositorio(_contexto);
        }

        public void Salvar()
        {
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}

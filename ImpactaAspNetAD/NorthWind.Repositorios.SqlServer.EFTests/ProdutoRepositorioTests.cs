using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Dominio;
using System.Linq;

namespace Loja.Repositorios.SqlServer.EF.Tests
{
    [TestClass()]
    public class ProdutoRepositorioTests
    {
        private static LojaDbContext _contexto = new LojaDbContext();
        private ProdutoRepositorio _produtoRepositorio = new ProdutoRepositorio(_contexto);
        private CategoriaRepositorio _categoriaRepositorio = new CategoriaRepositorio(_contexto);

        [TestMethod()]
        public void InserirProdutoTeste()
        {
            var produto = new Produto();
            produto.Categoria = _categoriaRepositorio.Obter(1);
            produto.Estoque = 34;
            produto.Nome = "Caneta";
            produto.Preco = 22.63m;

            _produtoRepositorio.Adicionar(produto);

            _contexto.SaveChanges();
        }

        [TestMethod]
        public void InserirProdutoUowTeste()
        {
            using (var lojaUow = new LojaUnitOfWork())
            {
                var produto = new Produto();
                produto.Categoria = lojaUow.Categorias.Obter(1);
                produto.Estoque = 41;
                produto.Nome = "Lápis";
                produto.Preco = 10.41m;

                lojaUow.Produtos.Adicionar(produto);

                lojaUow.SaveChanges();
            }
        }

        [TestMethod]
        public void AtualizarProdutoUowTeste()
        {
            using (var lojaUow = new LojaUnitOfWork())
            {
                var produto = lojaUow.Produtos.Obter(p => p.Id == 1).Single();
                produto.Estoque = 49;
                produto.Preco = 10.49m;

                lojaUow.SaveChanges();
            }
        }

        [TestMethod]
        public void RemoverProdutoUowTeste()
        {
            using (var lojaUow = new LojaUnitOfWork())
            {
                lojaUow.Produtos.Remover(2);

                lojaUow.SaveChanges();
            }
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Dominio;

namespace NorthWind.Repositorios.SqlServer.EF.Tests
{
    [TestClass()]
    public class ProdutoRepositorioTests
    {
        ProdutoRepositorio _produtoRepositorio = new ProdutoRepositorio();
        CategoriaRepositorio _categoriaRepositorio = new CategoriaRepositorio();

        [TestMethod()]
        public void InserirProdutoTeste()
        {
            var produto = new Produto();
            produto.Categoria = _categoriaRepositorio.Selecionar(1);
            produto.Estoque = 34;
            produto.Nome = "Caneta";
            produto.Preco = 22.63m;

            _produtoRepositorio.Inserir(produto);
        }
    }
}
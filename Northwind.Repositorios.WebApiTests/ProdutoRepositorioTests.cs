using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthWind.ViewModels;
using System.Configuration;

namespace Northwind.Repositorios.WebApi.Tests
{
    [TestClass()]
    public class ProdutoRepositorioTests
    {
        ProdutoRepositorio _repositorio = new ProdutoRepositorio(ConfigurationManager.AppSettings["urlApiNorthwind"] + "Produtos");

        [TestMethod()]
        public void GetTest()
        {
            var produtos = _repositorio.Get().Result;

            Assert.IsTrue(produtos.Count != 0);
        }

        [TestMethod()]
        public void GetByNameTest()
        {
            var produtos = _repositorio.GetByName("caneta").Result;

            Assert.IsTrue(produtos.Count != 0);
        }

        [TestMethod()]
        public void PostTest()
        {
            var produto = new Produto();
            produto.Nome = "Corretivo líquido";
            produto.Preco = 16.57m;
            produto.Categoria = new Categoria { Id = 1 };

            _repositorio.Post(produto).Wait();

            var produtos = _repositorio.GetByName("corretivo").Result;

            Assert.IsTrue(produtos.Count != 0);
        }

        [TestMethod]
        public void PutTeste()
        {
            var produto = _repositorio.Get(47).Result;

            produto.Preco = 17.05m;

            _repositorio.Put(produto.Id, produto).Wait();

            produto = _repositorio.Get(47).Result;

            Assert.AreEqual(produto.Preco, 17.05m);
        }

        [TestMethod]
        public void DeleteTeste()
        {
            _repositorio.Delete(47).Wait();

            var produto = _repositorio.Get(47).Result;

            Assert.IsNull(produto);
        }
    }
}
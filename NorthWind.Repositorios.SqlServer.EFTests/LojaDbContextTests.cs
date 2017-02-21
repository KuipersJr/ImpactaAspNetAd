using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Dominio;
using System.Data.Entity;
using System.Linq;
using NorthWind.Repositorios.SqlServer.EF.Migrations;
using System.Data.Entity.Migrations;

namespace NorthWind.Repositorios.SqlServer.EF.Tests
{
    [TestClass()]
    public class LojaDbContextTests
    {
        private static LojaDbContext _contexto = new LojaDbContext();

        //[ClassInitialize]
        //public static void Inicializar(TestContext testContext)
        //{
        //    // 3o. Roda uma vez apenas para essa classe, independentemente da quantidade de testes que ela tenha.
        //    //_contexto.Database.Initialize(force: true);
        //}

        [TestMethod()]
        public void LojaDbContextTest()
        {
            // 1o.
            //using (var contexto = new LojaDbContext())
            //{
            //    var papelaria = new Categoria { Nome = "Papelaria" };

            //    contexto.Categorias.Add(papelaria);
            //    contexto.SaveChanges();
            //}

            // 2o.
            //new LojaDbContext().Database.Initialize(false);
        }

        [TestMethod()]
        public void InserirProdutoTest()
        {
            var caneta = new Produto();
            caneta.Nome = "Caneta";
            caneta.Preco = 15.42m;
            caneta.Estoque = 42;
            //caneta.Categoria = _contexto.Categorias.Single(ComparararNomeCategoria);
            //caneta.Categoria = _contexto.Categorias.Single(delegate (Categoria c) { return c.Nome == "Papelaria"; });
            //caneta.Categoria = _contexto.Categorias.Single((Categoria c) => c.Nome == "Papelaria");
            caneta.Categoria = _contexto.Categorias.Single(c => c.Nome == "Papelaria");

            _contexto.Produtos.AddOrUpdate(p => p.Nome, caneta);

            _contexto.SaveChanges();
        }

        private bool ComparararNomeCategoria(Categoria c) { return c.Nome == "Papelaria"; }

        [ClassCleanup]
        public static void DescartarContexto()
        {
            _contexto.Database.Delete();
            _contexto.Dispose();
        }
    }
}
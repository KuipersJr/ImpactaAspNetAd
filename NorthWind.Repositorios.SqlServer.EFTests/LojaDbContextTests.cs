using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Dominio;
using System.Data.Entity;
using System.Linq;
using NorthWind.Repositorios.SqlServer.EF.Migrations;
using System.Data.Entity.Migrations;
using System.Diagnostics;

namespace NorthWind.Repositorios.SqlServer.EF.Tests
{
    [TestClass()]
    public class LojaDbContextTests
    {
        private static LojaDbContext _contexto = new LojaDbContext();

        [ClassInitialize]
        public static void Inicializar(TestContext testContext)
        {
            // 3o. Roda uma vez apenas para essa classe, independentemente da quantidade de testes que ela tenha.
            //_contexto.Database.Initialize(force: true);

            _contexto.Database.Log = q => Debug.WriteLine(q);
        }

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

        [TestMethod]
        public void InserirProdutoComCategoriaTeste()
        {
            var barbeador = new Produto();
            barbeador.Nome = "Barbeador";
            barbeador.Preco = 104.60m;
            barbeador.Estoque = 46;
            barbeador.Categoria = new Categoria { Nome = "Perfumaria" };

            _contexto.Produtos.AddOrUpdate(p => p.Nome, barbeador);

            _contexto.SaveChanges();
        }

        [TestMethod]
        public void EditarProduto()
        {
            var grampeador = _contexto.Produtos.Single(p => p.Nome == "Grampeador");

            grampeador.Preco = 0;
            grampeador.Descontinuado = true;

            _contexto.SaveChanges();

            grampeador = _contexto.Produtos.Single(p => p.Nome == "Grampeador");

            Assert.IsTrue(grampeador.Descontinuado);
        }

        [TestMethod]
        public void ExcluirProdutoDeInformatica()
        {
            var papelaria = _contexto.Produtos.Where(p => p.Categoria.Id == 2).ToList();

            _contexto.Produtos.RemoveRange(papelaria);

            _contexto.SaveChanges();

            Assert.IsFalse(_contexto.Produtos.Any(p => p.Categoria.Id == 2));
        }

        [TestMethod]
        public void ObterPrecoMedioPapelaria()
        {
            var media = _contexto.Produtos.Where(p => p.Categoria.Id == 1 && !p.Descontinuado).Average(p => p.Preco);

            Assert.AreNotEqual(media, 0m);
        }

        [TestMethod]
        public void ObterProdutosDePapelaria()
        {
            var produtosDePapelaria = _contexto.Categorias.Where(c => c.Nome == "Papelaria").SelectMany(c => c.Produtos).ToList();

            Assert.AreNotEqual(produtosDePapelaria.Count, 0);
        }

        [TestMethod]
        public void LazyLoadTeste()
        {
            // 1o - rodar assim.
            // 2o - colocar o virtual nas properties e inverter os comentários.
            // 3o - demonstrar que são feitas duas queries.

            var grampeador = _contexto.Produtos.Single(p => p.Nome == "Grampeador");
            System.Console.WriteLine(grampeador.Categoria.Nome);
            //Assert.IsNull(grampeador.Categoria);

            var papelaria = _contexto.Categorias.First();
            System.Console.WriteLine(papelaria.Produtos[0].Nome);
            //Assert.IsNull(papelaria.Produtos);
        }

        [TestMethod]
        public void IncludeTeste()
        {
            var grampeador = _contexto.Produtos.Single(p => p.Nome == "Grampeador");
            Assert.IsNull(grampeador.Categoria);

            grampeador = _contexto.Produtos.Include(p => p.Categoria).Single(p => p.Nome == "Grampeador");
            //System.Console.WriteLine(grampeador.Categoria.Nome);
        }

        [TestMethod]
        public void QueryableTeste()
        {
            var categoriaPapelaria = _contexto.Categorias.Where/*Single*/(c => c.Nome == "Papelaria");

            System.Console.WriteLine(categoriaPapelaria.Single());
        }

        [TestMethod]
        public void AdicionarCliente()
        {
            var cliente = new Cliente();
            cliente.Nome = "Vítor";
            cliente.Endereco = new Endereco { Logradouro = "R. Tal" };

            _contexto.Clientes.Add(cliente);

            _contexto.SaveChanges();
        }

        [TestMethod]
        public void ExlcuirCliente()
        {
            var cliente = _contexto.Clientes.Single(c => c.Id == 1);

            _contexto.Clientes.Remove(cliente);

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
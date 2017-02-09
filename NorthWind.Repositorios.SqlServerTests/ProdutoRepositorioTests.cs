using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Console; // Mencionar.

namespace NorthWind.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class ProdutoRepositorioTests
    {
        [TestMethod()]
        public void ObterTest()
        {
            var produtosDataTable = new ProdutoRepositorio().ObterPorCategoria(1);

            Assert.AreNotEqual(produtosDataTable.Rows.Count, 0);

            // using static do .NET 6.0.
            WriteLine(produtosDataTable.Rows[0]["ProductName"]);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NorthWind.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class FornecedorRepositorioTests
    {
        [TestMethod()]
        public void ObterTest()
        {
            var fornecedores = new FornecedorRepositorio().Obter();

            Assert.AreNotEqual(fornecedores.Rows.Count, 0);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthWind.Repositorios.SqlServer.Ado;

namespace NorthWind.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class FornecedorRepositorioTests
    {
        [TestMethod()]
        public void ObterTest()
        {
            var fornecedores = new FornecedorRepositorio().Selecionar();

            Assert.AreNotEqual(fornecedores.Rows.Count, 0);
        }
    }
}
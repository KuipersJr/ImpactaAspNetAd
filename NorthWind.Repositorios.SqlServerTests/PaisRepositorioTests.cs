using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NorthWind.Repositorios.SqlServer.Ado.Tests
{
    [TestClass()]
    public class PaisRepositorioTests
    {
        [TestMethod()]
        public void SelecionarTest()
        {
            var paises = new PaisRepositorio().Selecionar();

            Assert.AreNotEqual(paises.Count, 0);
        }
    }
}
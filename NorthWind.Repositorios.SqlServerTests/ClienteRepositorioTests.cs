using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NorthWind.Repositorios.SqlServer.Ado.Tests
{
    [TestClass()]
    public class ClienteRepositorioTests
    {
        [TestMethod()]
        public void SelecionarPorPaisTest()
        {
            var clientesAlemaes = new ClienteRepositorio().SelecionarPorPais("Germany");

            Assert.AreNotEqual(clientesAlemaes.Count, 0);
        }
    }
}
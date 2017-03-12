using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NorthWind.Repositorios.SqlServer.EF.ModelFirst.Tests
{
    [TestClass()]
    public class NorthwindContainerTests
    {
        [TestMethod()]
        public void NorthwindContainerTest()
        {
            var contexto = new NorthwindContainer();

            var categoria = new Categoria();
            categoria.Nome = "Papelaria";

            contexto.Categoria.Add(categoria);

            contexto.SaveChanges();
        }
    }
}
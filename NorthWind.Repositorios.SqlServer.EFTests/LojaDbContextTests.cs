using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Dominio;

namespace NorthWind.Repositorios.SqlServer.EF.Tests
{
    [TestClass()]
    public class LojaDbContextTests
    {
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
            new LojaDbContext().Database.Initialize(false);
        }
    }
}
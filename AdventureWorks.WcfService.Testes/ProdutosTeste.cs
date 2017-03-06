using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureWorks.WcfService.Testes.AdventureWorksServiceReference;
using System.Linq;

namespace AdventureWorks.WcfService.Testes
{
    [TestClass]
    public class ProdutosTeste
    {
        [TestMethod]
        public void GetTeste()
        {
            using (var produtosClient = new ProdutosClient())
            {
                var produto = produtosClient.Get(4);

                Assert.IsTrue(produto.Name == "Headset Ball Bearings");
            }
        }

        [TestMethod]
        public void GetByNameTeste()
        {
            using (var produtosClient = new ProdutosClient())
            {
                var produtos = produtosClient.GetByName("Mountain");

                Assert.IsTrue(produtos.Count() == 94);
            }
        }
    }
}
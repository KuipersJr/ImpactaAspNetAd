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
                produtosClient.Incrementar();

                Assert.IsTrue(produto.Name == "Headset Ball Bearings");
                var contador = produtosClient.ObterContador();
                Assert.IsTrue(contador == 2);
            }
        }

        [TestMethod]
        public void GetByNameTeste()
        {
            using (var produtosClient = new ProdutosClient())
            {
                var produtos = produtosClient.GetByName("Mountain");
                produtosClient.Incrementar();

                Assert.IsTrue(produtos.Count() == 94);
                Assert.IsTrue(produtosClient.ObterContador() == 4);
            }
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Northwind.WebApi.Testes
{
    [TestClass]
    public class ProdutoTeste
    {
        [TestMethod]
        public void PutTeste()
        {
            var produto = Get(1).Result;

            produto.Preco = 18.33m;

            //Put(produto).ContinueWith(t => produto = Get(35).Result);

            Put(produto).Wait();

            produto = Get(1).Result;

            Assert.IsTrue(produto.Preco == 18.33m);

            //Get(35).ContinueWith(AtualizarPreco);
        }

        [TestMethod]
        public void DeleteTeste()
        {
            Delete(34).Wait();
            var produto = Get(34).Result;

            Assert.IsNull(produto);
        }

        [TestMethod]
        public void GetByNameTeste()
        {
            var produtos = GetByName("caneta").Result;

            Assert.AreNotEqual(produtos.Count, 0);
        }

        private async Task Put(Produto produto)
        {
            using (var cliente = new HttpClient())
            {
                using (var response = await cliente.PutAsJsonAsync($"http://localhost/Northwind.WebApi/api/produtos/{produto.Id}", produto))
                {
                    response.EnsureSuccessStatusCode();
                }
            }
        }

        private async Task<Produto> Get(int id)
        {
            using (var cliente = new HttpClient())
            {
                using (var response = await cliente.GetAsync($"http://localhost/Northwind.WebApi/api/produtos/{id}"))
                {
                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadAsAsync<Produto>();
                }
            }
        }        

        private async Task Delete(int id)
        {
            using (var cliente = new HttpClient())
            {
                using (var response = await cliente.DeleteAsync($"http://localhost/Northwind.WebApi/api/produtos/{id}"))
                {
                    response.EnsureSuccessStatusCode();
                }
            }
        }

        private async Task<List<Produto>> GetByName(string nome)
        {
            using (var cliente = new HttpClient())
            {
                using (var response = await cliente.GetAsync($"http://localhost:51218/api/Produtos/GetByName/{nome}"))
                {
                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadAsAsync<List<Produto>>();
                }
            }
        }
    }
}

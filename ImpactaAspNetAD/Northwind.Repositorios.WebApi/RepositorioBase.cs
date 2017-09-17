using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Loja.Repositorios.WebApi
{
    public class RepositorioBase<T>
    {
        private string _url;

        public RepositorioBase(string url)
        {
            _url = url;
        }

        public async Task<T> Post(T entidade)
        {
            using (var cliente = new HttpClient())
            {
                using (var resposta = await cliente.PostAsJsonAsync($"{_url}", entidade))
                {
                    resposta.EnsureSuccessStatusCode();

                    return await resposta.Content.ReadAsAsync<T>();
                }
            }
        }

        public async Task Put(int id, T entidade)
        {
            using (var cliente = new HttpClient())
            {
                using (var response = await cliente.PutAsJsonAsync($"{_url.TrimEnd('/')}/{id}", entidade))
                {
                    response.EnsureSuccessStatusCode();
                }
            }
        }

        public async Task<List<T>> Get(string acao = null)
        {
            using (var cliente = new HttpClient())
            {
                using (var response = await cliente.GetAsync($"{_url.TrimEnd('/')}/{acao ?? string.Empty}"))
                {
                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadAsAsync<List<T>>();
                }
            }
        }

        public async Task<T> Get(int id)
        {
            using (var cliente = new HttpClient())
            {
                using (var response = await cliente.GetAsync($"{_url.TrimEnd('/')}/{id}"))
                {
                    //response.EnsureSuccessStatusCode();

                    return await response.Content.ReadAsAsync<T>();
                }
            }
        }

        public async Task Delete(int id)
        {
            using (var cliente = new HttpClient())
            {
                using (var response = await cliente.DeleteAsync($"{_url.TrimEnd('/')}/{id}"))
                {
                    response.EnsureSuccessStatusCode();
                }
            }
        }
    }
}
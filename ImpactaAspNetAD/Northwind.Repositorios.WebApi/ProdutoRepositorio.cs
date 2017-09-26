using NorthWind.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Repositorios.WebApi
{
    public class ProdutoRepositorio : RepositorioBase<Produto>
    {
        public ProdutoRepositorio(string urlProdutos) : base(urlProdutos)
        {

        }

        public async Task<List<Produto>> GetByName(string nome)
        {
            return await Get($"{nameof(this.GetByName)}/{nome}");
        }
    }
}
using Loja.Dominio;
using Loja.Mvc.Models;
using System.Collections.Generic;

namespace Loja.Mvc.Helpers
{
    public class Mapeamento
    {
        private List<ProdutoViewModel> Mapear(List<Produto> produtos)
        {
            var produtosViewModel = new List<ProdutoViewModel>();

            foreach (var produto in produtos)
            {
                produtosViewModel.Add(Mapear(produto));
            }

            return produtosViewModel;
        }

        private ProdutoViewModel Mapear(Produto produto)
        {
            var viewModel = new ProdutoViewModel();

            viewModel.Id = produto.Id;
            viewModel.Nome = produto.Nome;

            return viewModel;
        }
    }
}
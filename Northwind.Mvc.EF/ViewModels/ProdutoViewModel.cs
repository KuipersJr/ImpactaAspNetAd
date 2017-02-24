using Northwind.Dominio;
using System.Collections.Generic;

namespace Northwind.Mvc.EF.ViewModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {

        }

        public ProdutoViewModel(List<Categoria> categorias, Produto produto = null)
        {
            Produto = produto ?? new Produto();
            Categorias  = categorias;
            CategoriaSelecionadaId = produto != null ? produto.Categoria.Id : (int?)null;
        }

        public Produto Produto { get; set; }

        public int? CategoriaSelecionadaId { get; set; }
        public List<Categoria> Categorias { get; set; }
    }
}
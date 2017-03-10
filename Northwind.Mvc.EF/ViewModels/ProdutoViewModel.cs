using Northwind.Dominio;
using System.Collections.Generic;

namespace Northwind.Mvc.EF.ViewModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel(List<Categoria> categorias, Produto produto = null)
        {
            Produto = produto ?? new Produto();
            Categorias  = categorias;
        }

        public Produto Produto { get; set; }
        public List<Categoria> Categorias { get; set; }
    }
}
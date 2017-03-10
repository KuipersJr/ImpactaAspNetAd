using Northwind.Dominio;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Northwind.Mvc.EF.ViewModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {

        }

        public ProdutoViewModel(List<Categoria> categorias, Produto produto = null)
        {
            Categorias = new List<SelectListItem>();

            categorias.ForEach(c => Categorias.Add(new SelectListItem { Text = c.Nome, Value = c.Id.ToString() }));

            if (produto != null)
            {
                Id = produto.Id;
                CategoriaId = produto.Categoria.Id;
                PossuiImagem = produto.Imagem != null;
                Nome = produto.Nome;
                Preco = produto.Preco;
                Estoque = produto.Estoque;
                Descontinuado = produto.Descontinuado;
            }
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        public bool PossuiImagem { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Preço")]
        public decimal? Preco { get; set; }

        [Required]
        public int? Estoque { get; set; }

        public bool Descontinuado { get; set; }

        public List<SelectListItem> Categorias { get; set; }
    }
}
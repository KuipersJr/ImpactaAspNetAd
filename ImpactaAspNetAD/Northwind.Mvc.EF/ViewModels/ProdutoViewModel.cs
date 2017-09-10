﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Northwind.Mvc.EF.ViewModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            Categorias = new List<SelectListItem>();
        } 

        public int Id { get; set; }

        [Display(Name = "Categoria")]
        public string CategoriaNome { get; internal set; }

        [Required]
        [Display(Name = "Categoria")]
        public int? CategoriaId { get; set; }

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
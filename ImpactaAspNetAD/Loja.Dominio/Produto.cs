using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Loja.Dominio
{
    //[Table("Produto")]
    public class Produto
    {
        public int Id { get; set; }

        // virtual - habilita o lazy load.
        public int Categoria_Id { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual List<Pedido> Pedidos { get; set; }
        public virtual ProdutoImagem Imagem { get; set; }

        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }

        // Colocar depois - migration.
        public bool Descontinuado { get; set; }

        public static bool ValidarFormatoImagem(string contentType)
        {
            return Regex.IsMatch(contentType, @"image/.+");
        }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dominio
{
    //[Table("Produto")]
    public class Produto
    {
        public int Id { get; set; }

        // virtual - habilita o lazy load.
        public virtual Categoria Categoria { get; set; }
        public virtual List<Pedido> Pedidos { get; set; }
        public virtual ProdutoImagem Imagem { get; set; }

        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public bool Descontinuado { get; set; }
    }
}
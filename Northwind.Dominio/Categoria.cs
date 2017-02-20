using System.Collections.Generic;

namespace Northwind.Dominio
{
    public class Categoria
    {
        public int Id { get; set; }

        public List<Produto> Produtos { get; set; }

        public string Nome { get; set; }
    }
}
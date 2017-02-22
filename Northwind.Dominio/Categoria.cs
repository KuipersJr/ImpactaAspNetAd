using System.Collections.Generic;

namespace Northwind.Dominio
{
    public class Categoria
    {
        public int Id { get; set; }

        public virtual List<Produto> Produtos { get; set; }
        
        //[Index("CategoriaNomeUK", 1, IsUnique = true)]
        public string Nome { get; set; }
    }
}
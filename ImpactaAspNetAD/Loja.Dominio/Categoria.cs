using System.Collections.Generic;

// Tem que adicionar referência para o Entity Framework, precário.
//using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Dominio
{
    public class Categoria
    {
        public int Id { get; set; }

        public virtual List<Produto> Produtos { get; set; }
        
        //[Index("CategoriaNomeUK", 1, IsUnique = true)]
        public string Nome { get; set; }
    }
}
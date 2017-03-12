using System.Collections.Generic;

namespace NorthWind.ViewModels
{
    public partial class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    
        public virtual List<Produto> Produtos { get; set; }
    }
}

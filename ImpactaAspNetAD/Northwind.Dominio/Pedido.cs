using System.Collections.Generic;

namespace Northwind.Dominio
{
    public class Pedido
    {
        public int Id { get; set; }
        public virtual List<Produto> Produtos { get; set; }
    }
}
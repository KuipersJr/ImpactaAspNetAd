namespace Northwind.Dominio
{
    public class Produto
    {
        public int Id { get; set; }

        public Categoria Categoria { get; set; }

        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        //public bool Descontinuado { get; set; }
    }
}
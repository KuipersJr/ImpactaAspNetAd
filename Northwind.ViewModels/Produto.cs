namespace NorthWind.ViewModels
{
    public partial class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    
        public virtual Categoria Categoria { get; set; }
    }
}
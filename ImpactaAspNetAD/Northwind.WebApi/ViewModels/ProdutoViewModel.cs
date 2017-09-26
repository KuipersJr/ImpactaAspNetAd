using NorthWind.Repositorios.SqlServer.EF.ModelFirst;

namespace Loja.WebApi.ViewModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel(Produto produto)
        {
            Id = produto.Id;
            Nome = produto.Nome;
            Preco = produto.Preco;

            Categoria = new CategoriaViewModel {Id = produto.Categoria.Id, Nome = produto.Categoria.Nome };
        }

        public int Id { get; set; }
        public CategoriaViewModel Categoria { get; set; }

        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
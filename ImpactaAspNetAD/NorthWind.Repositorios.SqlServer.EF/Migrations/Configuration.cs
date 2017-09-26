namespace Loja.Repositorios.SqlServer.EF.Migrations
{
    using Loja.Dominio;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<LojaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(LojaDbContext contexto)
        {
            if (!contexto.Categorias.Any())
            {
                contexto.Categorias.AddRange(ObterCategorias());
                contexto.SaveChanges();
            }

            if (!contexto.Produtos.Any())
            {
                contexto.Produtos.AddRange(ObterProdutos(contexto));
                contexto.SaveChanges();
            }
        }

        private List<Produto> ObterProdutos(LojaDbContext contexto)
        {
            var grampeador = new Produto();
            grampeador.Nome = "Grampeador";
            grampeador.Preco = 16.06m;
            grampeador.Estoque = 6;
            grampeador.Categoria = contexto.Categorias.Single(c => c.Nome == "Papelaria");

            var penDrive = new Produto();
            penDrive.Nome = "Pen drive";
            penDrive.Preco = 19.22m;
            penDrive.Estoque = 22;
            penDrive.Categoria = contexto.Categorias.Single(c => c.Nome == "Informática");

            return new List<Produto> { grampeador, penDrive };
        }

        private List<Categoria> ObterCategorias()
        {
            return new List<Categoria> {
                new Categoria { Nome = "Papelaria" },
                new Categoria { Nome = "Informática" }
            };
        }
    }
}
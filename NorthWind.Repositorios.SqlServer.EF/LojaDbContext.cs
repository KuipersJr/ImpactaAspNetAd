using Northwind.Dominio;
using System.Data.Entity;

namespace NorthWind.Repositorios.SqlServer.EF
{
    public class LojaDbContext : DbContext
    {
        public LojaDbContext() : base("lojaConnectionString")
        {
            Database.SetInitializer(new LojaDbInitializer());
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
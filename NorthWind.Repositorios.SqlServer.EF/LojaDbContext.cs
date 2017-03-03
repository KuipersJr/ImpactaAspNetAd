using Northwind.Dominio;
using NorthWind.Repositorios.SqlServer.EF.Migrations;
using NorthWind.Repositorios.SqlServer.EF.ModelConfiguration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NorthWind.Repositorios.SqlServer.EF
{
    public class LojaDbContext : DbContext
    {
        public LojaDbContext() : base("name=lojaConnectionString")
        {
            //Database.SetInitializer(new LojaDbInitializer());

            // Migrations
            //  1. Enable-Migrations
            //  2. add-migration Inicial
            //  3. Update-Database -ConnectionStringName "lojaConnectionString" // não esquecer de comentar o Up.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LojaDbContext, Configuration>());
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new ProdutoImagemConfiguration());
            modelBuilder.Configurations.Add(new CategoriaConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new EnderecoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
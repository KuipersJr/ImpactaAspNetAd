using Northwind.Dominio;
using System.Data.Entity;

namespace Pubs.Repositorios.SqlServer.EF.CodeFirst
{
    public class PubsDbContext : DbContext
    {
        // Your context has been configured to use a 'Pubs' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Pubs.Repositorios.SqlServer.EF.CodeFirst.Pubs' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Pubs' 
        // connection string in the application configuration file.
        public PubsDbContext() : base("name=Pubs")
        {

        }

        public virtual DbSet<Autor> Autores { get; set; }
        public virtual DbSet<Publicacao> Publicacoes { get; set; }
    }
}
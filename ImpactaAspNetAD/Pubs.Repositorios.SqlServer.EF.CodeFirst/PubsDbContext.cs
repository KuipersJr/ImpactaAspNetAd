using Northwind.Dominio;
using System.Data.Entity;

namespace Pubs.Repositorios.SqlServer.EF.CodeFirst
{
    public class PubsDbContext : DbContext
    {
        public PubsDbContext() : base("name=Pubs")
        {

        }

        public virtual DbSet<Autor> Autores { get; set; }
        public virtual DbSet<Publicacao> Publicacoes { get; set; }
    }
}
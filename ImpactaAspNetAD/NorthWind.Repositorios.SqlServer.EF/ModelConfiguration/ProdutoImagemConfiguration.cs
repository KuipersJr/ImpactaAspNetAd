using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorios.SqlServer.EF.ModelConfiguration
{
    public class ProdutoImagemConfiguration : EntityTypeConfiguration<ProdutoImagem>
    {
        public ProdutoImagemConfiguration()
        {
            HasKey(pi => pi.ProdutoId);

            Property(pi => pi.ContentType)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
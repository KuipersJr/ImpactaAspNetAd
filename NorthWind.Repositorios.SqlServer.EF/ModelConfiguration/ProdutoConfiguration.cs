using Northwind.Dominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace NorthWind.Repositorios.SqlServer.EF
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            //ToTable("Product");

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnType("nvarchar")
                .HasColumnAnnotation("Index", new IndexAnnotation(new[] { new IndexAttribute("ProdutoNomeUK") { IsUnique = true } }));

            Property(p => p.Preco).HasPrecision(9, 2);

            HasRequired(c => c.Categoria);

            HasRequired(c => c.Imagem)
                .WithRequiredPrincipal(e => e.Produto)
                .WillCascadeOnDelete(true);
        }
    }
}
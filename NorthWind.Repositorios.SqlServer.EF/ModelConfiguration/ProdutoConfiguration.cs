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
                .HasColumnAnnotation("Index", DefinirChaveUnica("ProdutoNomeCategoriaUK", 0));

            Property(p => p.Categoria_Id)
                .HasColumnAnnotation("Index", DefinirChaveUnica("ProdutoNomeCategoriaUK", 1));

            Property(p => p.Preco).HasPrecision(9, 2);

            HasRequired(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.Categoria_Id);
            
            HasOptional(c => c.Imagem)
                .WithRequired(pi => pi.Produto)
                .WillCascadeOnDelete(true);
        }

        private IndexAnnotation DefinirChaveUnica(string nomeChave, int ordem)
        {
            var indexAttribute = new IndexAttribute(nomeChave) { IsUnique = true, Order = ordem };
            var indexAnnotation = new IndexAnnotation(indexAttribute);

            return indexAnnotation;
        }
    }
}
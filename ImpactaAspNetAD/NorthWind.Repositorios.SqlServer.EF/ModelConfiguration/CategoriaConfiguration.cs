using Loja.Dominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorios.SqlServer.EF.ModelConfiguration
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            var indexAttribute = new IndexAttribute("CategoriaNomeUK") { IsUnique = true };
            var indexAnnotation = new IndexAnnotation(indexAttribute);

            Property(p => p.Nome)
                .IsRequired()
                //.HasColumnName("")
                .HasMaxLength(15)
                .HasColumnType("nvarchar")
                .HasColumnAnnotation("Index", indexAnnotation);
        }
    }
}
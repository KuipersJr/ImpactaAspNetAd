using Northwind.Dominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace NorthWind.Repositorios.SqlServer.EF.ModelConfiguration
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnType("nvarchar")
                .HasColumnAnnotation("Index", new IndexAnnotation(new[] { new IndexAttribute("CategoriaNomeUK") { IsUnique = true } }));
        }
    }
}
using Northwind.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace NorthWind.Repositorios.SqlServer.EF.ModeloConfiguration
{
    public class EnderecoConfiguration : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfiguration()
        {
            HasKey(e => e.ClienteId);

            HasRequired(e => e.Cliente)
                .WithRequiredDependent(c => c.Endereco)
                .WillCascadeOnDelete(true);
        }
    }
}
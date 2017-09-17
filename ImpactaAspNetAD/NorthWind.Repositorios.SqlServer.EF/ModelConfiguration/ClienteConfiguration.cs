using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorios.SqlServer.EF.ModelConfiguration
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasRequired(c => c.Endereco)
                .WithRequiredPrincipal(e => e.Cliente)
                .WillCascadeOnDelete(true);
        }
    }
}
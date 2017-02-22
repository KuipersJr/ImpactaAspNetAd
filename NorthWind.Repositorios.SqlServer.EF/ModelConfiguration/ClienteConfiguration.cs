using Northwind.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace NorthWind.Repositorios.SqlServer.EF.ModelConfigurarion
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasRequired(a => a.Endereco);
        }
    }
}
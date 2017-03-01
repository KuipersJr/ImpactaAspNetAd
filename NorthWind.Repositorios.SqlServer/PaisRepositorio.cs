using Northwind.Dominio;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NorthWind.Repositorios.SqlServer.Ado
{
    public class PaisRepositorio : RepositorioListaBase
    {
        public List<Pais> Selecionar()
        {
            return base.ExecuteReader<Pais>("PaisSelecionar", Mapear, null);
        }

        private Pais Mapear(SqlDataReader reader)
        {
            var pais = new Pais();
            pais.Nome = reader["Country"].ToString();

            return pais;
        }
    }
}

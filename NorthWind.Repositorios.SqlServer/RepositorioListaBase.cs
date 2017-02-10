using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NorthWind.Repositorios.SqlServer
{
    public class RepositorioListaBase
    {
        protected string _stringConexao = ConfigurationManager.ConnectionStrings["northWindConnectionString"].ConnectionString;

        // params - apresentar depois.
        protected void ExecuteNonQuery(string nomeProcedure, params SqlParameter[] parametros)
        {
            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();                

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddRange(parametros);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
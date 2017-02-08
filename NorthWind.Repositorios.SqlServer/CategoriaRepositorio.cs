using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NorthWind.Repositorios.SqlServer
{
    public class CategoriaRepositorio
    {
        public DataTable Obter()
        {
            var dataTable = new DataTable();

            using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["oficinaConnectionString"].ConnectionString))
            {
                conexao.Open();

                const string instrucao = @"SELECT [Id]
                      ,[Nome]
                      ,[Email]
                      ,[DataNascimento]
                      ,Tipo
                  FROM [Oficina].[dbo].[Cliente]
                  Where Nome like '%' + @nome + '%'";

                using (var comando = new SqlCommand(instrucao, conexao))
                {
                    using (var dataAdapter = new SqlDataAdapter(comando))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
    }
}

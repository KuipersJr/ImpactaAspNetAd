using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NorthWind.Repositorios.SqlServer.Ado
{
    public class RepositorioDataTableBase
    {
        // Trocar depois por private.
        protected string _conexao = ConfigurationManager.ConnectionStrings["northWindConnectionString"].ConnectionString;

        // 1 - começar assim.
        protected DataTable Obter(string instrucao)
        {
            var dataTable = new DataTable();

            // northWindConnectionString - não é case sensitive.
            using (var conexao = new SqlConnection(_conexao))
            {
                conexao.Open();

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

        // 2 - depois refatorar.
        protected DataTable Obter_(string instrucao, List<SqlParameter> parametros = null)
        {
            var dataTable = new DataTable();

            // northWindConnectionString - não é case sensitive.
            using (var conexao = new SqlConnection(_conexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand(instrucao, conexao))
                {
                    using (var dataAdapter = new SqlDataAdapter(comando))
                    {
                        if (parametros != null)
                        {
                            dataAdapter.SelectCommand.Parameters.AddRange(parametros.ToArray());
                        }

                        dataAdapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
    }
}
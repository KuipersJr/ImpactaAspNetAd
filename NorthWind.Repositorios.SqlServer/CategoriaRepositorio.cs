using System.Data;
using System.Data.SqlClient;

namespace NorthWind.Repositorios.SqlServer
{
    public class CategoriaRepositorio : RepositorioDataTableBase
    {
        // 1 - Começar assim
        public DataTable Obter()
        {
            var categoriasDataTable = new DataTable();

            // northWindConnectionString - não é case sensitive.
            using (var conexao = new SqlConnection(_conexao))
            {
                conexao.Open();

                const string instrucao = @"SELECT CategoryId, CategoryName FROM Categories";

                using (var comando = new SqlCommand(instrucao, conexao))
                {
                    using (var dataAdapter = new SqlDataAdapter(comando))
                    {
                        dataAdapter.Fill(categoriasDataTable);
                    }
                }
            }

            return categoriasDataTable;
        }

        // 2 - Depois refatorar.
        //public DataTable Obter()
        //{
        //    return base.Obter(@"SELECT CategoryId, CategoryName FROM Categories");
        //}
    }
}

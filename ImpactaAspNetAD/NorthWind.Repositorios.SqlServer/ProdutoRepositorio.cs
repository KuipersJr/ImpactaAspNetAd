using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NorthWind.Repositorios.SqlServer
{
    public class ProdutoRepositorio : RepositorioDataTableBase
    {
        // 1 - começar assim.
        public DataTable ObterPorCategoria(int categoriaId)
        {
            var produtosDataTable = new DataTable();

            using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["northWindConnectionString"].ConnectionString))
            {
                conexao.Open();

                const string instrucao = @"SELECT ProductName,
                                            UnitPrice,
                                            UnitsInStock
                                            FROM Products
                                            WHERE CategoryId = @CategoryId";

                using (var comando = new SqlCommand(instrucao, conexao))
                {
                    using (var dataAdapter = new SqlDataAdapter(comando))
                    {
                        // CategoryId ou @CategoryId.
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@CategoryId", categoriaId);
                        dataAdapter.Fill(produtosDataTable);
                    }
                }
            }

            return produtosDataTable;
        }

        // 2 - depois refatorar.
        //public DataTable Obter(int categoriaId)
        //{
        //    const string instrucao = @"SELECT ProductName,
        //                                   UnitPrice,
        //                                   UnitsInStock
        //                                   FROM Products
        //                                   WHERE CategoryId=@CategoryId";

        //    var parametros = new List<SqlParameter> { new SqlParameter("@CategoryId", categoriaId) };

        //    return base.Obter(instrucao, parametros);
        //}

        public DataTable ObterPorFornecedor(int fornecedorId)
        {
            var instrucao = ObterQuery() + " WHERE SupplierId = @SupplierId";

            var parametros = new List<SqlParameter> { new SqlParameter("@SupplierId", fornecedorId) };

            return base.Obter_(instrucao, parametros);
        }

        private static string ObterQuery()
        {
            return @"SELECT ProductName,
                            UnitPrice,
                            UnitsInStock
                    FROM Products ";
        }
    }
}
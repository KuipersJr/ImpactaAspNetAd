using System.Data;

namespace NorthWind.Repositorios.SqlServer
{
    public class FornecedorRepositorio : RepositorioDataTableBase
    {
        public DataTable Selecionar()
        {
            return base.Obter(@"SELECT SupplierId, CompanyName FROM Suppliers");
        }
    }
}
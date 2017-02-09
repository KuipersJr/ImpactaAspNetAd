using System.Data;

namespace NorthWind.Repositorios.SqlServer
{
    public class FornecedorRepositorio : RepositorioDataTableBase
    {
        public DataTable Obter()
        {
            return base.Obter(@"SELECT SupplierId, CompanyName FROM Suppliers");
        }
    }
}
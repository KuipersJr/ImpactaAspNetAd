using AdventureWorks.Repositorios.SqlServer.EF.DatabaseFirst;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace AdventureWorks.WcfService
{
    [ServiceContract]
    public interface IProdutos
    {
        [OperationContract]
        Product Get(int id);

        [OperationContract]
        List<Product> GetByName(string nome);
    }
}
using AdventureWorks.Repositorios.SqlServer.EF.DatabaseFirst;
using System.Collections.Generic;
using System.ServiceModel;

namespace AdventureWorks.WcfService
{
    [ServiceContract]
    public interface IProdutos
    {        
        [OperationContract]
        Product Get(int id);

        [OperationContract]
        List<Product> GetByName(string nome);

        [OperationContract]
        void Incrementar();

        [OperationContract]
        int ObterContador();
    }
}
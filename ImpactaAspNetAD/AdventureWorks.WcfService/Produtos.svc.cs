using AdventureWorks.Repositorios.SqlServer.EF.DatabaseFirst;
using System.Collections.Generic;
using System.Linq;
//using System.Data.Entity;

namespace AdventureWorks.WcfService
{
    public class Produtos : IProdutos
    {
        private static int Contador { get; set; }

        public Product Get(int id)
        {
            using (var contexto = new AdventureWorks2012Entities())
            {
                return contexto.Products.SingleOrDefault(p => p.ProductID == id);

                //contexto.Configuration.ProxyCreationEnabled = false;
                //var produto = contexto.Products.Include(p => p.ProductModel).SingleOrDefault(p => p.ProductID == id);

                /*
                namespace AdventureWorks.Repositorios.DbFirst
                {
                    [DataContract(IsReference = true)]
                    public partial class ProductModel
                    {
                        [DataMember]
                        public string Name { get; set; }             
                 */
            }
        }

        public List<Product> GetByName(string nome)
        {
            using (var contexto = new AdventureWorks2012Entities())
            {
                return contexto.Products.Where(p => p.Name.Contains(nome)).ToList();
            }
        }

        public void Incrementar()
        {
            Contador++;
        }

        public int ObterContador()
        {
            return Contador;
        }
    }
}
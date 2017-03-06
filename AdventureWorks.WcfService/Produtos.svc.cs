using AdventureWorks.Repositorios.SqlServer.EF.DatabaseFirst;
using System.Collections.Generic;
using System.Linq;

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
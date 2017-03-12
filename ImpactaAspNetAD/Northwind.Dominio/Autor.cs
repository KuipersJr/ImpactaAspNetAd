using System.Collections.Generic;

namespace Northwind.Dominio
{
    public class Autor
    {
        public int Id { get; set; }
        public List<Publicacao> Publicacoes { get; set; }

        public string Nome { get; set; }        
    }
}
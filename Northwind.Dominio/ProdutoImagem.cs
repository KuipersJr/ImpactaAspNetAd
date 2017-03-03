using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Northwind.Dominio
{
    public class ProdutoImagem
    {
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public byte[] Bytes { get; set; }

        //[RegularExpression(@"image/.+", ErrorMessage = "Apenas imagens são aceitas.")]
        public string ContentType { get; set; }
    }
}
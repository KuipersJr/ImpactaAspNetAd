using System.ComponentModel.DataAnnotations;

namespace Northwind.Dominio
{
    public class Transportadora
    {
        public int Id { get; set; }

        [Required()]
        [MinLength(3, ErrorMessage = "O Nome deve ter no mínimo 3 caracteres.")]
        public string Nome { get; set; }

        [Required()]
        [Display(Name = "Phone")]
        [RegularExpression(@"^\([1-9]{2}\)\s?[2-9][0-9]{3,4}-[0-9]{4}$", ErrorMessage = "Digite o Telefone no formato (99) 9999-9999")]
        public string Telefone { get; set; }
    }
}
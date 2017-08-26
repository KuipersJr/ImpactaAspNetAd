using System.ComponentModel.DataAnnotations;

namespace Northwind.Mvc.Ado.ViewModels
{
    public class TransportadoraViewModel
    {
        private string _telefone;

        public int Id { get; set; }

        [Required()]
        [MinLength(3, ErrorMessage = "O Nome deve ter no mínimo 3 caracteres.")]
        public string Nome { get; set; }

        [Required()]
        [Display(Name = "Telefone")]
        [RegularExpression(@"^(\([1-9]{2}\))\s?([9]{1})?([0-9_]{4,5})-([0-9_]{4,5})$", ErrorMessage = "Digite o Telefone no formato (99) [9]9999-9999")]
        public string Telefone
        {
            get { return _telefone?.Replace("_", string.Empty); }
            set { _telefone = value?.Replace("_", string.Empty); }
        }
    }
}
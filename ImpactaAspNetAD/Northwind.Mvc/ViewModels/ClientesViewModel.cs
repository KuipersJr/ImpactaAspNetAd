using Northwind.Dominio;
using System.Collections.Generic;
using System.ComponentModel;

namespace Northwind.Mvc.Ado.ViewModels
{
    public class ClientesViewModel
    {
        public ClientesViewModel(string nomePais, List<Pais> paises, List<Cliente> clientes)
        {
            PaisSelecionado = nomePais;
            Paises = paises;
            Clientes = clientes;
        }

        [DisplayName("País")]
        public string PaisSelecionado { get; set; }

        public List<Pais> Paises { get; set; }

        public List<Cliente> Clientes { get; set; }
    }
}
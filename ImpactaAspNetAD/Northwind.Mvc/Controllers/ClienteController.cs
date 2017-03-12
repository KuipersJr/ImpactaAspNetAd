using Northwind.Dominio;
using Northwind.Mvc.Ado.ViewModels;
using NorthWind.Repositorios.SqlServer.Ado;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Northwind.Mvc.Ado.Controllers
{
    public class ClienteController : Controller
    {
        PaisRepositorio _paisRepositorio = new PaisRepositorio();
        ClienteRepositorio _clienteRepositorio = new ClienteRepositorio();

        public ActionResult Index(string nomePais = null)
        {
            var paises = _paisRepositorio.Selecionar();
            var clientes = nomePais != null ? _clienteRepositorio.SelecionarPorPais(nomePais) : new List<Cliente>();

            return View(new ClientesViewModel(nomePais, paises, clientes));
        }        
    }
}
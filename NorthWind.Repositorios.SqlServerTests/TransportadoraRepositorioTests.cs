using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Dominio;
using System.Linq;

namespace NorthWind.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class TransportadoraRepositorioTests
    {
        TransportadoraRepositorio _transportadoraRepositorio = new TransportadoraRepositorio();

        [TestMethod()]
        public void SelecionarTest()
        {
            var transportadoras = _transportadoraRepositorio.Selecionar();

            Assert.AreNotEqual(transportadoras.Count, 0);

            foreach (var transportadora in transportadoras)
            {
                System.Console.WriteLine($"{transportadora.Id} - {transportadora.Nome} ({transportadora.Telefone})");
            }
        }

        [TestMethod()]
        public void InserirTest()
        {
            var transportadora = new Transportadora();
            transportadora.Nome = "Correios";
            transportadora.Telefone = "+5511 1234 1234";

            _transportadoraRepositorio.Inserir(transportadora);

            var transportadoras = _transportadoraRepositorio.Selecionar();

            Assert.IsTrue(transportadoras.Any(t => t.Nome == "Correios"));
        }

        [TestMethod()]
        public void AtualizarTest()
        {
            var transportadoras = _transportadoraRepositorio.Selecionar();
            var correios = transportadoras.Single(t => t.Nome == "Correios");

            correios.Nome = "Correios Editado";

            _transportadoraRepositorio.Atualizar(correios);

            transportadoras = _transportadoraRepositorio.Selecionar();

            Assert.IsTrue(transportadoras.Any(t => t.Nome == "Correios Editado"));
        }

        [TestMethod()]
        public void ExcluirTest()
        {
            var transportadoras = _transportadoraRepositorio.Selecionar();
            var correios = transportadoras.Single(t => t.Nome == "Correios Editado");

            _transportadoraRepositorio.Excluir(correios.Id);

            transportadoras = _transportadoraRepositorio.Selecionar();

            Assert.IsFalse(transportadoras.Any(t => t.Nome == "Correios Editado"));
        }
    }
}
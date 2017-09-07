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

        //[TestMethod()]
        private int InserirTest()
        {
            var transportadora = new Transportadora();
            transportadora.Nome = "Correios";
            transportadora.Telefone = "+5511 1234 1234";

            Assert.IsTrue(transportadora.Id == 0);

            _transportadoraRepositorio.Inserir(transportadora);

            Assert.IsFalse(transportadora.Id == 0);

            var transportadoras = _transportadoraRepositorio.Selecionar();

            Assert.IsTrue(transportadoras.Any(t => t.Nome == "Correios"));

            return transportadora.Id;
        }

        //[TestMethod()]
        private void AtualizarTest(int id)
        {
            var transportadora = _transportadoraRepositorio.Selecionar(id);

            transportadora.Nome = "Correios Editado";

            _transportadoraRepositorio.Atualizar(transportadora);

            transportadora = _transportadoraRepositorio.Selecionar(id);

            Assert.IsTrue(transportadora.Nome == "Correios Editado");
        }

        //[TestMethod()]
        private void ExcluirTest(int id)
        {
            _transportadoraRepositorio.Excluir(id);

            var transportadora = _transportadoraRepositorio.Selecionar(id);

            Assert.IsNull(transportadora);
        }

        [TestMethod()]
        public void CudTeste()
        {
            var id = InserirTest();
            AtualizarTest(id);
            ExcluirTest(id);
        }

        [TestMethod()]
        public void SelecionarPorIdTest()
        {
            var transportadora = _transportadoraRepositorio.Selecionar(1);
            Assert.IsNotNull(transportadora);

            transportadora = _transportadoraRepositorio.Selecionar(10);
            Assert.IsNull(transportadora);
        }
    }
}
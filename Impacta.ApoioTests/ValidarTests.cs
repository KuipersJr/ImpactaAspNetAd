using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Dominio;

namespace Impacta.Apoio.Tests
{
    [TestClass()]
    public class ValidarTests
    {
        [TestMethod()]
        public void DataAnnotationsTest()
        {
            var transportadora = new Transportadora();

            try
            {
                Validar.DataAnnotations(transportadora);
            }
            catch (DataAnnotationValidationException excecao)
            {
                foreach (var erro in excecao.ErrosValidacao)
                {
                    System.Console.WriteLine(erro.ErrorMessage);
                }
            }

            transportadora.Nome = "Correios";
            transportadora.Telefone = "s.d65f.asd65f.s5";

            try
            {
                Validar.DataAnnotations(transportadora);
            }
            catch (DataAnnotationValidationException excecao)
            {
                foreach (var erro in excecao.ErrosValidacao)
                {
                    System.Console.WriteLine(erro.ErrorMessage);
                }
            }

            transportadora.Telefone = "(54) 4568-4544";
            try
            {
                Validar.DataAnnotations(transportadora);
            }
            catch (DataAnnotationValidationException excecao)
            {
                Assert.IsTrue(excecao.ErrosValidacao.Count == 0);
            }
        }
    }
}
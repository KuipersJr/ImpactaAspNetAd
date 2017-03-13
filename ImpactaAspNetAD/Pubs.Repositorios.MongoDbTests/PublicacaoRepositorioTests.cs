using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pubs.Dominio;
using System;
using System.Linq;

namespace Pubs.Repositorios.MongoDb.Tests
{
    [TestClass()]
    public class PublicacaoRepositorioTests
    {
        PublicacaoRepositorio _repositorio = new PublicacaoRepositorio();

        [TestMethod()]
        public void InserirTest()
        {
            var publicacao = new Publicacao();

            publicacao.Autor = "Vítor";
            publicacao.Texto = "Conteúdo da publicação";
            publicacao.Titulo = "Título da publicação";
            publicacao.Comentarios.Add(new Comentario { Autor = "Fulano" });

            _repositorio.Inserir(publicacao);
        }

        [TestMethod]
        public void SelecionarTodosTeste()
        {
            var publicacoes = _repositorio.Selecionar();

            foreach (var publicacao in publicacoes)
            {
                Console.WriteLine(publicacao.DataPublicacao);
                Console.WriteLine(publicacao.Comentarios[0].Id);
                Console.WriteLine(publicacao.Id);
            }
        }

        [TestMethod]
        public void SelecionarPorIdTeste()
        {
            var publicacao = _repositorio.Selecionar(new Guid("0e093ab0-f963-4eee-822f-09c0de54116d"));

            Console.WriteLine(publicacao.Id);
        }

        [TestMethod]
        public void SelecionarPorLinqTeste()
        {
            var publicacao = _repositorio.Selecionar(p => p.Autor == "Vítor").First();

            Assert.AreEqual(publicacao.Autor, "Vítor");
        }

        [TestMethod]
        public void AtualizarTeste()
        {
            var publicacao = _repositorio.Selecionar(p => p.Autor == "Vítor").First();

            publicacao.Autor = "Avelino";

            _repositorio.Atualizar(publicacao);

            publicacao = _repositorio.Selecionar(p => p.Autor == "Avelino").First();

            Assert.AreEqual(publicacao.Autor, "Avelino");
        }

        [TestMethod]
        public void ExcluirTeste()
        {
            _repositorio.Excluir(new Guid("1a1fffae-85b0-4252-ab88-328136d3fc1f"));

            var publicacao = _repositorio.Selecionar(new Guid("1a1fffae-85b0-4252-ab88-328136d3fc1f"));

            Assert.IsNull(publicacao);
        }
    }
}
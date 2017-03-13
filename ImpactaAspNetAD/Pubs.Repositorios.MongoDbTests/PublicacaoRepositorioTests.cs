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
            var publicacao = _repositorio.Selecionar(new Guid("b25cdb3f-6ac0-40f1-927a-a2a84a5aad83"));

            Console.WriteLine(publicacao.Id);
        }

        [TestMethod]
        public void SelecionarPorLinqTeste()
        {
            var publicacao = _repositorio.Selecionar(p => p.Autor == "avelino").First(); // Case sensitive.

            Assert.AreEqual(publicacao.Autor, "avelino");
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
            _repositorio.Excluir(new Guid("b25cdb3f-6ac0-40f1-927a-a2a84a5aad83"));

            var publicacao = _repositorio.Selecionar(new Guid("b25cdb3f-6ac0-40f1-927a-a2a84a5aad83"));

            Assert.IsNull(publicacao);
        }
    }
}
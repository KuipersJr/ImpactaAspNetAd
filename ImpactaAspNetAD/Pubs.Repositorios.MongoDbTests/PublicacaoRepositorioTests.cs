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

            publicacao.Autor = new Autor { Nome = "Vítor Avelino" };
            publicacao.Texto = "Conteúdo da publicação";
            publicacao.Titulo = "Título da publicação";
            publicacao.Comentarios.Add(new Comentario { Autor = new Autor { Nome = "Fulano" }, Texto = "Texto do comentário" });

            _repositorio.Inserir(publicacao);

            /*
             C:\Program Files\MongoDB\Server\3.4\bin\mongo.exe
             use Pubs
             db.getCollectionNames()
             db.Publicacao.find()                         
             */
        }

        [TestMethod]
        public void SelecionarTodosTeste()
        {
            var publicacoes = _repositorio.Selecionar();

            foreach (var publicacao in publicacoes)
            {
                Console.WriteLine(publicacao.Id);
            }
        }

        [TestMethod]
        public void SelecionarPorIdTeste()
        {
            var publicacao = _repositorio.Selecionar(new Guid("9619d4e8-7c25-4a82-97b6-f12bcdca30c8"));

            Assert.IsNotNull(publicacao);
        }

        [TestMethod]
        public void SelecionarPorLinqTeste()
        {
            var publicacao = _repositorio.Selecionar(p => p.Autor.Nome.Contains("Vítor")).First(); // Case sensitive.

            Assert.IsNotNull(publicacao);
        }

        [TestMethod]
        public void AtualizarTeste()
        {
            var publicacao = _repositorio.Selecionar(p => p.Autor.Nome.Contains("Vítor")).First();

            publicacao.Autor.Nome = "Avelino Vítor";

            _repositorio.Atualizar(publicacao);

            publicacao = _repositorio.Selecionar(p => p.Autor.Nome.Contains("Vítor")).First();

            Assert.AreEqual(publicacao.Autor.Nome, "Avelino Vítor");

            /*
             db.Publicacao.find({"Titulo": "Título alterado"})  
             db.Publicacao.find({"Autor.Nome": "Avelino Vítor"})             
             */
            //db.Publicacao.find({ "Autor.Nome": /.* Vítor.*/ i})
        }

        [TestMethod]
        public void ExcluirTeste()
        {
            _repositorio.Excluir(new Guid("9619d4e8-7c25-4a82-97b6-f12bcdca30c8"));

            var publicacao = _repositorio.Selecionar(new Guid("9619d4e8-7c25-4a82-97b6-f12bcdca30c8"));

            Assert.IsNull(publicacao);
        }
    }
}
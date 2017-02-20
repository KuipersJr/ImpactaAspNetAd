using Northwind.Dominio;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthWind.Repositorios.SqlServer.EF
{
    public class LojaDbInitializer : DropCreateDatabaseIfModelChanges<LojaDbContext>
    {
        protected override void Seed(LojaDbContext contexto)
        {
            contexto.Categorias.AddRange(ObterCategorias());
            contexto.SaveChanges();

            contexto.Produtos.AddRange(ObterProdutos(contexto));
            contexto.SaveChanges();
        }

        private IEnumerable<Produto> ObterProdutos(LojaDbContext contexto)
        {
            var grampeador = new Produto();
            grampeador.Nome = "Grampeador";
            grampeador.Preco = 16.06m;
            grampeador.Estoque = 6;
            grampeador.Categoria = contexto.Categorias.Single(c => c.Nome == "Papelaria");

            var penDrive = new Produto();
            penDrive.Nome = "Pen drive";
            penDrive.Preco = 19.22m;
            penDrive.Estoque = 22;
            penDrive.Categoria = contexto.Categorias.Single(c => c.Nome == "Informática");

            return new List<Produto> { grampeador, penDrive };
        }

        private IEnumerable<Categoria> ObterCategorias()
        {
            return new List<Categoria> {
                new Categoria { Nome = "Papelaria" },
                new Categoria { Nome = "Informática" }
            };
        }
    }
}
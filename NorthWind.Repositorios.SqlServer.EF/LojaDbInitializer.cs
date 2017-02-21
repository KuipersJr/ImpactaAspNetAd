﻿using Northwind.Dominio;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;

namespace NorthWind.Repositorios.SqlServer.EF
{
    public class LojaDbInitializer : DropCreateDatabaseAlways<LojaDbContext>
    {
        protected override void Seed(LojaDbContext contexto)
        {
            var categorias = ObterCategorias();

            contexto.Categorias.AddOrUpdate(c => c.Nome, categorias[0]);
            contexto.Categorias.AddOrUpdate(c => c.Nome, categorias[1]);
            contexto.SaveChanges();

            var produtos = ObterProdutos(contexto);

            contexto.Produtos.AddOrUpdate(p => p.Nome, produtos[0]);
            contexto.Produtos.AddOrUpdate(p => p.Nome, produtos[1]);
            contexto.SaveChanges();
        }

        private List<Produto> ObterProdutos(LojaDbContext contexto)
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

        private List<Categoria> ObterCategorias()
        {
            return new List<Categoria> {
                new Categoria { Nome = "Papelaria" },
                new Categoria { Nome = "Informática" }
            };
        }
    }
}
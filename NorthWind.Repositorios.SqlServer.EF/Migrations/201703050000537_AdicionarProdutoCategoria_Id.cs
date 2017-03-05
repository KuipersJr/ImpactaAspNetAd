namespace NorthWind.Repositorios.SqlServer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarProdutoCategoria_Id : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Categoria", "CategoriaNomeUK");
            DropIndex("dbo.Produto", "ProdutoNomeUK");
            DropIndex("dbo.Produto", new[] { "Categoria_Id" });
            CreateIndex("dbo.Categoria", "Nome", unique: true, name: "CategoriaNomeUK");
            CreateIndex("dbo.Produto", new[] { "Nome", "Categoria_Id" }, unique: true, name: "ProdutoNomeCategoriaUK");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Produto", "ProdutoNomeCategoriaUK");
            DropIndex("dbo.Categoria", "CategoriaNomeUK");
            CreateIndex("dbo.Produto", "Categoria_Id");
            CreateIndex("dbo.Produto", "Nome", unique: true, name: "ProdutoNomeUK");
            CreateIndex("dbo.Categoria", "Nome", unique: true, name: "CategoriaNomeUK");
        }
    }
}

namespace NorthWind.Repositorios.SqlServer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nome = c.String(nullable: false, maxLength: 15),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nome, unique: true, name: "CategoriaNomeUK");

            CreateTable(
                "dbo.Produto",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nome = c.String(nullable: false, maxLength: 40),
                    Preco = c.Decimal(nullable: false, precision: 9, scale: 2),
                    Estoque = c.Int(nullable: false),
                    Categoria_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.Categoria_Id, cascadeDelete: true)
                .Index(t => t.Nome, unique: true, name: "ProdutoNomeUK")
                .Index(t => t.Categoria_Id);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "Categoria_Id", "dbo.Categoria");
            DropIndex("dbo.Produto", new[] { "Categoria_Id" });
            DropIndex("dbo.Produto", "ProdutoNomeUK");
            DropIndex("dbo.Categoria", "CategoriaNomeUK");
            DropTable("dbo.Produto");
            DropTable("dbo.Categoria");
        }
    }
}

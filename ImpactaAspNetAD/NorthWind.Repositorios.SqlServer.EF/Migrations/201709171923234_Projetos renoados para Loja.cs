namespace Loja.Repositorios.SqlServer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjetosrenoadosparaLoja : DbMigration
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
                        Categoria_Id = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 40),
                        Preco = c.Decimal(nullable: false, precision: 9, scale: 2),
                        Estoque = c.Int(nullable: false),
                        Descontinuado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.Categoria_Id)
                .Index(t => new { t.Nome, t.Categoria_Id }, unique: true, name: "ProdutoNomeCategoriaUK");
            
            CreateTable(
                "dbo.ProdutoImagem",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false),
                        Bytes = c.Binary(),
                        ContentType = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Produto", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.ProdutoId);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Nome = c.String(),
                        Telefone = c.String(),
                        Cidade = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        ClienteId = c.Int(nullable: false),
                        Logradouro = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.PedidoProduto",
                c => new
                    {
                        Pedido_Id = c.Int(nullable: false),
                        Produto_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pedido_Id, t.Produto_Id })
                .ForeignKey("dbo.Pedido", t => t.Pedido_Id, cascadeDelete: true)
                .ForeignKey("dbo.Produto", t => t.Produto_Id, cascadeDelete: true)
                .Index(t => t.Pedido_Id)
                .Index(t => t.Produto_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Endereco", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.PedidoProduto", "Produto_Id", "dbo.Produto");
            DropForeignKey("dbo.PedidoProduto", "Pedido_Id", "dbo.Pedido");
            DropForeignKey("dbo.ProdutoImagem", "ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.Produto", "Categoria_Id", "dbo.Categoria");
            DropIndex("dbo.PedidoProduto", new[] { "Produto_Id" });
            DropIndex("dbo.PedidoProduto", new[] { "Pedido_Id" });
            DropIndex("dbo.Endereco", new[] { "ClienteId" });
            DropIndex("dbo.ProdutoImagem", new[] { "ProdutoId" });
            DropIndex("dbo.Produto", "ProdutoNomeCategoriaUK");
            DropIndex("dbo.Categoria", "CategoriaNomeUK");
            DropTable("dbo.PedidoProduto");
            DropTable("dbo.Endereco");
            DropTable("dbo.Cliente");
            DropTable("dbo.Pedido");
            DropTable("dbo.ProdutoImagem");
            DropTable("dbo.Produto");
            DropTable("dbo.Categoria");
        }
    }
}

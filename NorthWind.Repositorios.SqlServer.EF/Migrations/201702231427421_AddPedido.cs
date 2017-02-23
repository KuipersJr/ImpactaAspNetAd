namespace NorthWind.Repositorios.SqlServer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPedido : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropForeignKey("dbo.PedidoProduto", "Produto_Id", "dbo.Produto");
            DropForeignKey("dbo.PedidoProduto", "Pedido_Id", "dbo.Pedido");
            DropIndex("dbo.PedidoProduto", new[] { "Produto_Id" });
            DropIndex("dbo.PedidoProduto", new[] { "Pedido_Id" });
            DropTable("dbo.PedidoProduto");
            DropTable("dbo.Pedido");
        }
    }
}

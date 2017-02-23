namespace NorthWind.Repositorios.SqlServer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Endereco", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Endereco", new[] { "ClienteId" });
            DropTable("dbo.Endereco");
            DropTable("dbo.Cliente");
        }
    }
}

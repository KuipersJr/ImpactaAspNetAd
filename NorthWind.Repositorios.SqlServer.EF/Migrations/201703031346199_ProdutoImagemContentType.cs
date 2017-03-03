namespace NorthWind.Repositorios.SqlServer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProdutoImagemContentType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProdutoImagem", "ContentType", c => c.String(nullable: false, maxLength: 50, defaultValue: string.Empty));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProdutoImagem", "ContentType");
        }
    }
}

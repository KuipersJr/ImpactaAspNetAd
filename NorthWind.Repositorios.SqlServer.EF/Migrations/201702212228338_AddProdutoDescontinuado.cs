namespace NorthWind.Repositorios.SqlServer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProdutoDescontinuado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "Descontinuado", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produto", "Descontinuado");
        }
    }
}

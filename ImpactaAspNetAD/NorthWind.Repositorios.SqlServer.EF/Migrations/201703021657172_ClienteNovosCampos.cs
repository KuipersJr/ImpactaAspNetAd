namespace NorthWind.Repositorios.SqlServer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClienteNovosCampos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "Codigo", c => c.String());
            AddColumn("dbo.Cliente", "Telefone", c => c.String());
            AddColumn("dbo.Cliente", "Cidade", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cliente", "Cidade");
            DropColumn("dbo.Cliente", "Telefone");
            DropColumn("dbo.Cliente", "Codigo");
        }
    }
}

namespace NorthWind.Repositorios.SqlServer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProdutoImagemBytes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProdutoImagem", "Bytes", c => c.Binary());
            DropColumn("dbo.ProdutoImagem", "Imagem");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProdutoImagem", "Imagem", c => c.Binary());
            DropColumn("dbo.ProdutoImagem", "Bytes");
        }
    }
}

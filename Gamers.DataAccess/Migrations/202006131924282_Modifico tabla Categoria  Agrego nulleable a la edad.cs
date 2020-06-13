namespace Gamers.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificotablaCategoriaAgregonulleablealaedad : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categoria", "EdadMinima", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categoria", "EdadMinima", c => c.Int(nullable: false));
        }
    }
}

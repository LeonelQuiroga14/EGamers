namespace Gamers.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agregoindice : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Categoria", "Descripcion", unique: true, name: "IX_DescripcionUnica");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Categoria", "IX_DescripcionUnica");
        }
    }
}

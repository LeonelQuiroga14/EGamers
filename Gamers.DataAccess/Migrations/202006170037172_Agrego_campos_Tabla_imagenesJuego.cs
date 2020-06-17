namespace Gamers.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agrego_campos_Tabla_imagenesJuego : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImagenesJuego", "ImageName", c => c.String());
            AddColumn("dbo.ImagenesJuego", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ImagenesJuego", "IsActive");
            DropColumn("dbo.ImagenesJuego", "ImageName");
        }
    }
}

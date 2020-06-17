namespace Gamers.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class configdbset : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ImagenesJuego", "Imagen", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ImagenesJuego", "Imagen", c => c.Binary());
        }
    }
}

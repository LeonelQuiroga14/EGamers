namespace Gamers.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agrego_TablaImagenes_para_Juegos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImagenesJuego",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Imagen = c.Binary(),
                        JuegoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Juego", t => t.JuegoId, cascadeDelete: true)
                .Index(t => t.JuegoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImagenesJuego", "JuegoId", "dbo.Juego");
            DropIndex("dbo.ImagenesJuego", new[] { "JuegoId" });
            DropTable("dbo.ImagenesJuego");
        }
    }
}

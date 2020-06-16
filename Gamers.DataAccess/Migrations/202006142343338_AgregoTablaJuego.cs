namespace Gamers.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregoTablaJuego : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Juego",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Requerimientos = c.String(),
                        FechaLanzamiento = c.DateTime(nullable: false),
                        Precio = c.Double(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Juego", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Juego", new[] { "CategoriaId" });
            DropTable("dbo.Juego");
        }
    }
}

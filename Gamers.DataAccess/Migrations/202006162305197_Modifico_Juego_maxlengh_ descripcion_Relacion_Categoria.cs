namespace Gamers.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modifico_Juego_maxlengh_descripcion_Relacion_Categoria : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Juego", "IX_DescripcionUnica");
            DropIndex("dbo.Juego", new[] { "CategoriaId" });
            AlterColumn("dbo.Juego", "Descripcion", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Juego", new[] { "Descripcion", "CategoriaId" }, unique: true, name: "IX_Descripcion_Categoria");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Juego", "IX_Descripcion_Categoria");
            AlterColumn("dbo.Juego", "Descripcion", c => c.String(nullable: false, maxLength: 400));
            CreateIndex("dbo.Juego", "CategoriaId");
            CreateIndex("dbo.Juego", "Descripcion", unique: true, name: "IX_DescripcionUnica");
        }
    }
}

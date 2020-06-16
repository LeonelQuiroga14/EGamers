namespace Gamers.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modificaciondelatablajuegosprimarykeymaxlengthyunique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Juego", "Descripcion", c => c.String(nullable: false, maxLength: 400));
            CreateIndex("dbo.Juego", "Descripcion", unique: true, name: "IX_DescripcionUnica");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Juego", "IX_DescripcionUnica");
            AlterColumn("dbo.Juego", "Descripcion", c => c.String());
        }
    }
}

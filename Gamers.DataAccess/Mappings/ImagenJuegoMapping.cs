using Gamers.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamers.DataAccess.Mappings
{
   public class ImagenJuegoMapping: EntityTypeConfiguration<ImagenesJuego>
    {
        public ImagenJuegoMapping()
        {
            this.ToTable("ImagenesJuego");
            this.HasKey(x => x.Id);
            this.Property(x => x.Imagen).HasColumnType("varbinary");
            this.HasRequired<Juego>(t => t.Juego).WithMany(x => x.Imagenes).HasForeignKey(x => x.JuegoId);
        }
    }
}

using Gamers.DataAccess.Mappings;
using Gamers.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamers.DataAccess
{
    public class EGamersContext : DbContext
    {
       
        public EGamersContext() :base(ConfigurationManager.ConnectionStrings["EGamer"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new CategoriaMapping());
            modelBuilder.Configurations.Add(new JuegoMapping());
            modelBuilder.Configurations.Add(new ImagenJuegoMapping());
            #region Juego
            //modelBuilder.Entity<Juego>().HasKey(x=> x.Id)
            //    .Property(x => x.Descripcion).IsRequired().HasColumnType("nvarchar").HasMaxLength(400)
            //    .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_DescripcionUnica") { IsUnique = true }));
            #endregion
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Juego> Juego { get; set; }
        public DbSet<ImagenesJuego> ImagenesJuegos { get; set; }
    }
}

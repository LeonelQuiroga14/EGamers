using Gamers.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamers.DataAccess.Mappings
{
    public class JuegoMapping : EntityTypeConfiguration<Juego>
    {
        public JuegoMapping()
        {
            this.ToTable("Juego");
            this.HasKey(x => x.Id);
            this.Property(x => x.Descripcion).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            this.Property(x => x.CategoriaId).IsRequired().HasColumnType("int");
            //Relacion con categoria
            #region Relacion
            // el producto requiere una categoria (HasRequired), a su vez la categoria se relaciona con muchos juegos (WithMany), se relaciona por la property CategoriaId
            this.HasRequired<Categoria>(t => t.Categoria).WithMany(t => t.Juegos).HasForeignKey(f => f.CategoriaId);
            
            #endregion

            #region Indices
            const string IndexName= "IX_Descripcion_Categoria";
            this.Property(x=>x.Descripcion).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute(IndexName,1) { IsUnique = true }));
            this.Property(p => p.CategoriaId).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute(IndexName, 2) { IsUnique = true }));
            #endregion
        }
    }
}

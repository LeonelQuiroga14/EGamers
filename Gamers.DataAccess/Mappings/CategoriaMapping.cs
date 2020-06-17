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
    public   class CategoriaMapping : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMapping()
        {
            #region Categoria
            this.ToTable("Categoria");
            this.HasKey(x => x.Id);
            this.Property(x => x.Descripcion).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
        
            this.Property(x=>x.Descripcion).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_DescripcionUnica") { IsUnique = true }));
            #endregion
        }
    }
}

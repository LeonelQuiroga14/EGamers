using Gamers.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
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
            #region Categoria
            modelBuilder.Entity<Categoria>().HasKey(x => x.Id)
                .Property(x => x.Descripcion).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
                                    
            #endregion
        }

        public DbSet<Categoria> Categoria { get; set; }
    }
}

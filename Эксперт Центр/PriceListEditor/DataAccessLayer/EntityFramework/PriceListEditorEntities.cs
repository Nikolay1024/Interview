using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer.EntityFramework
{
    public partial class PriceListEditorEntities : DbContext
    {
        public PriceListEditorEntities()
            : base("name=PriceListEditorEntities")
        {
        }

        public virtual DbSet<Cell> Cells { get; set; }
        public virtual DbSet<Column> Columns { get; set; }
        public virtual DbSet<PriceList> PriceLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cell>()
                .Property(e => e.Value)
                .IsFixedLength();

            modelBuilder.Entity<Column>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Column>()
                .Property(e => e.Type)
                .IsFixedLength();

            modelBuilder.Entity<Column>()
                .HasMany(e => e.Cells)
                .WithRequired(e => e.Column)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PriceList>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<PriceList>()
                .HasMany(e => e.Columns)
                .WithRequired(e => e.PriceList)
                .WillCascadeOnDelete(false);
        }
    }
}

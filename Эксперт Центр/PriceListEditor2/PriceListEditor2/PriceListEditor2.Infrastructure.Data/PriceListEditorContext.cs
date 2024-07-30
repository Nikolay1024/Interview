using PriceListEditor2.Domain.Core;
using PriceListEditor2.Infrastructure.Data.Configurations;
using System.Data.Entity;

namespace PriceListEditor2.Infrastructure.Data
{
    public class PriceListEditorContext : DbContext
    {
        public PriceListEditorContext() : base()
        {
            //Database.SetInitializer(new PriceListEditorDbInitializer());
        }

        public DbSet<PriceListCell> PriceListCells { get; set; }
        public DbSet<PriceListColumn> PriceListColumns { get; set; }
        public DbSet<PriceListProduct> PriceListProducts { get; set; }
        public DbSet<PriceList> PriceLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PriceList>()
                .HasMany(p => p.PriceListProducts)
                .WithRequired(p => p.PriceList)
                .HasForeignKey(s => s.PriceListId)
                .WillCascadeOnDelete(false);
        }
    }
}

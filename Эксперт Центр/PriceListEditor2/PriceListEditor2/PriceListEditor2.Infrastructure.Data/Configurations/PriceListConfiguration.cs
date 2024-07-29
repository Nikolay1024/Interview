using PriceListEditor2.Domain.Core;
using System.Data.Entity.ModelConfiguration;

namespace PriceListEditor2.Infrastructure.Data.Configurations
{
    public class PriceListConfiguration : EntityTypeConfiguration<PriceList>
    {
        public PriceListConfiguration()
        {
        }
    }
}

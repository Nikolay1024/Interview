using PriceListEditor2.Domain.Core;
using PriceListEditor2.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceListEditor2.Infrastructure.Data.Repositories
{
    ///<inheritdoc cref="IPriceListColumnRepository">
    public class PriceListColumnRepository : BaseRepository, IPriceListColumnRepository, IDisposable
    {
        public void CreatePriceListColumns(List<PriceListColumn> priceListColumns)
        {
            _dbContext.PriceListColumns.AddRange(priceListColumns);
            _dbContext.SaveChanges();
        }

        public List<PriceListColumn> GetPriceListColumnsByPriceListId(int priceListId)
        {
            return _dbContext.PriceListColumns.Where(plc => plc.PriceListId == priceListId).ToList();
        }
    }
}

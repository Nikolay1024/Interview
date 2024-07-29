using PriceListEditor2.Domain.Core;
using PriceListEditor2.Domain.Interfaces;
using PriceListEditor2.Infrastructure.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PriceListEditor2.Infrastructure.Data.Repositories
{
    ///<inheritdoc cref="IPriceListRepository">
    public class PriceListRepository : BaseRepository, IPriceListRepository, IDisposable
    {
        public async Task<IEnumerable<PriceList>> GetFilteredListAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await PagedList<PriceList>.ToPagedListAsync(_dbContext.PriceLists.OrderByDescending(p => p.CreatedAt), page, pageSize, cancellationToken);
        }

        public PriceList GetPriceListById(int id)
        {
            return _dbContext.PriceLists.Find(id);
        }

        public void CreatePriceList(PriceList priceList)
        {
            _dbContext.PriceLists.Add(priceList);
            _dbContext.SaveChanges();
        }
    }
}

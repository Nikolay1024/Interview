using PriceListEditor2.Domain.Core;
using PriceListEditor2.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PriceListEditor2.Infrastructure.Data.Repositories
{
    ///<inheritdoc cref="IPriceListProductRepository">
    public class PriceListProductRepository : BaseRepository, IPriceListProductRepository, IDisposable
    {
        public async Task<int> CreatePriceListProductAsync(PriceListProduct priceListProduct, CancellationToken cancellationToken)
        {
            PriceListProduct result = _dbContext.PriceListProducts.Add(priceListProduct);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return result.Id;
        }

        public void Delete(int priceListProductId)
        {
            PriceListProduct priceListProduct = _dbContext.PriceListProducts.Find(priceListProductId);
            _dbContext.PriceListProducts.Remove(priceListProduct);
            _dbContext.SaveChanges();
        }
    }
}

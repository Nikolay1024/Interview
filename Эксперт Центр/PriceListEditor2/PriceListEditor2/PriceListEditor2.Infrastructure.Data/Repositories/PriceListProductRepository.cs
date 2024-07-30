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
        /// <summary>
        /// Добавляет товар в прайс-лист.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <param name="priceListProduct">Товар</param>
        /// <returns>Идентификатор товара, добавленного в прайс-лист.</returns>
        public async Task<int> CreatePriceListProductAsync(CancellationToken cancellationToken, PriceListProduct priceListProduct)
        {
            PriceListProduct result = _dbContext.PriceListProducts.Add(priceListProduct);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return result.Id;
        }

        /// <summary>
        /// Удаляет товар из прайс-листа по идентификатору товара.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <param name="priceListProductId">Идентификатор товара прайс-листа</param>
        public async Task DeletePriceListProductByIdAsync(CancellationToken cancellationToken, int priceListProductId)
        {
            PriceListProduct priceListProduct = await _dbContext.PriceListProducts.FindAsync(cancellationToken, priceListProductId);
            _dbContext.PriceListProducts.Remove(priceListProduct);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

using PriceListEditor2.Domain.Core;
using PriceListEditor2.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace PriceListEditor2.Infrastructure.Data.Repositories
{
    ///<inheritdoc cref="IPriceListRepository">
    public class PriceListRepository : BaseRepository, IPriceListRepository, IDisposable
    {
        /// <summary>
        /// Получает список прайс-листов.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список прайс-листов.</returns>
        public async Task<List<PriceList>> GetPriceListsAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.PriceLists.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Получает прайс-лист по идентификатору прайс-листа.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <param name="id">Идентификатор прайс-листа</param>
        /// <returns>Прайс-лист</returns>
        public async Task<PriceList> GetPriceListByIdAsync(CancellationToken cancellationToken, int id)
        {
            return await _dbContext.PriceLists.FindAsync(cancellationToken, id);
        }

        /// <summary>
        /// Создает новый прайс-лист.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <param name="priceList">Прайс-лист</param>
        public async Task CreatePriceListAsync(CancellationToken cancellationToken, PriceList priceList)
        {
            _dbContext.PriceLists.Add(priceList);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

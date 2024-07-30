using PriceListEditor2.Domain.Core;
using PriceListEditor2.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PriceListEditor2.Infrastructure.Data.Repositories
{
    ///<inheritdoc cref="IPriceListColumnRepository">
    public class PriceListColumnRepository : BaseRepository, IPriceListColumnRepository, IDisposable
    {
        /// <summary>
        /// Создает колонки прайс-листа.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <param name="priceListColumns">Столбцы прайс-листа</param>
        public async Task CreatePriceListColumnsAsync(CancellationToken cancellationToken, List<PriceListColumn> priceListColumns)
        {
            _dbContext.PriceListColumns.AddRange(priceListColumns);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Получает колонки прайс-листа по идентификатору прайс-листа.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <param name="priceListId">Идентификатор прайс-листа</param>
        /// <returns>Лист колонок прайс-листа.</returns>
        public async Task<List<PriceListColumn>> GetPriceListColumnsByPriceListIdAsync(CancellationToken cancellationToken, int priceListId)
        {
            return await _dbContext.PriceListColumns.Where(plc => plc.PriceListId == priceListId).ToListAsync(cancellationToken);
        }
    }
}

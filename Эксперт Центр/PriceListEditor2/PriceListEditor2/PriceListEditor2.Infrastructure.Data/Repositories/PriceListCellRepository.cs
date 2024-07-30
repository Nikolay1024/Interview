using PriceListEditor2.Domain.Core;
using PriceListEditor2.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PriceListEditor2.Infrastructure.Data.Repositories
{
    ///<inheritdoc cref="IPriceListCellRepository">
    public class PriceListCellRepository : BaseRepository, IPriceListCellRepository, IDisposable
    {
        /// <summary>
        /// Создает ячейки прайс листа.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <param name="priceListCells">Ячейки прайс-листа</param>
        public async Task CreatePriceListCellsAsync(CancellationToken cancellationToken, List<PriceListCell> priceListCells)
        {
            _dbContext.PriceListCells.AddRange(priceListCells);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

using PriceListEditor2.Domain.Core;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PriceListEditor2.Domain.Interfaces
{
    public interface IPriceListCellRepository
    {
        /// <summary>
        /// Создает ячейки прайс листа.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <param name="priceListCells">Ячейки прайс-листа</param>
        Task CreatePriceListCellsAsync(CancellationToken cancellationToken, List<PriceListCell> priceListCells);
    }
}

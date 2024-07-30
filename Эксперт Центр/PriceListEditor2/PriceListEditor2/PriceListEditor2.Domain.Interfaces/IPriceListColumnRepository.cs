using PriceListEditor2.Domain.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PriceListEditor2.Domain.Interfaces
{
    public interface IPriceListColumnRepository : IDisposable
    {
        /// <summary>
        /// Создает колонки прайс-листа.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <param name="priceListColumns">Столбцы прайс-листа</param>
        Task CreatePriceListColumnsAsync(CancellationToken cancellationToken, List<PriceListColumn> priceListColumns);

        /// <summary>
        /// Получает колонки прайс-листа по идентификатору прайс-листа.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <param name="priceListId">Идентификатор прайс-листа</param>
        /// <returns>Лист колонок прайс-листа.</returns>
        Task<List<PriceListColumn>> GetPriceListColumnsByPriceListIdAsync(CancellationToken cancellationToken, int priceListId);
    }
}

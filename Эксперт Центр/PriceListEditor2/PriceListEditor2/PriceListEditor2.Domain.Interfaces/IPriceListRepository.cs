using PriceListEditor2.Domain.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PriceListEditor2.Domain.Interfaces
{
    public interface IPriceListRepository : IDisposable
    {
        /// <summary>
        /// Получает список прайс-листов.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список прайс-листов.</returns>
        Task<List<PriceList>> GetPriceListsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает прайс-лист по идентификатору прайс-листа.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <param name="id">Идентификатор прайс-листа</param>
        /// <returns>Прайс-лист.</returns>
        Task<PriceList> GetPriceListByIdAsync(CancellationToken cancellationToken, int id);

        /// <summary>
        /// Создает новый прайс-лист.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <param name="priceList">Прайс-лист</param>
        Task CreatePriceListAsync(CancellationToken cancellationToken, PriceList priceList);
    }
}

using PriceListEditor2.Domain.Core;
using System.Threading;
using System.Threading.Tasks;

namespace PriceListEditor2.Domain.Interfaces
{
    public interface IPriceListProductRepository
    {
        /// <summary>
        /// Добавление товара в прайс-лист.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <param name="priceListProduct">Товар</param>
        /// <returns>Идентификатор товара, добавленного в прайс-лист.</returns>
        Task<int> CreatePriceListProductAsync(CancellationToken cancellationToken, PriceListProduct priceListProduct);

        /// <summary>
        /// Удаляет товар из прайс-листа по идентификатору товара.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <param name="priceListProductId">Идентификатор товара прайс-листа</param>
        Task DeletePriceListProductByIdAsync(CancellationToken cancellationToken, int priceListProductId);
    }
}

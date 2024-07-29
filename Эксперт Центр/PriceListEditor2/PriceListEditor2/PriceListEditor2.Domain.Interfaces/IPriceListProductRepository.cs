using PriceListEditor2.Domain.Core;
using System.Threading;
using System.Threading.Tasks;

namespace PriceListEditor2.Domain.Interfaces
{
    public interface IPriceListProductRepository
    {
        /// <summary>
        /// Добавление товара в прайс-лист
        /// </summary>
        /// <param name="product">Товар</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns></returns>
        Task<int> CreatePriceListProductAsync(PriceListProduct product, CancellationToken cancellationToken);
        
        void Delete(int priceListProductId);
    }
}

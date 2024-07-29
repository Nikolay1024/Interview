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
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PriceList>> GetFilteredListAsync(int page, int pageSize, CancellationToken cancellationToken);

        PriceList GetPriceListById(int id);

        void CreatePriceList(PriceList item);
    }
}

using PriceListEditor2.Domain.Core;
using System;
using System.Collections.Generic;

namespace PriceListEditor2.Domain.Interfaces
{
    public interface IPriceListColumnRepository : IDisposable
    {
        void CreatePriceListColumns(List<PriceListColumn> item);

        List<PriceListColumn> GetPriceListColumnsByPriceListId(int priceListId);
    }
}

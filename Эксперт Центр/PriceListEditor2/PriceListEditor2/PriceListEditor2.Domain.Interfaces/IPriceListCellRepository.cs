using PriceListEditor2.Domain.Core;
using System.Collections.Generic;

namespace PriceListEditor2.Domain.Interfaces
{
    public interface IPriceListCellRepository
    {
        void CreatePriceListCells(List<PriceListCell> cells);
    }
}

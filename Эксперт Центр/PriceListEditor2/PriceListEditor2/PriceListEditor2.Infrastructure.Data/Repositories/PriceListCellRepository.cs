using PriceListEditor2.Domain.Core;
using PriceListEditor2.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace PriceListEditor2.Infrastructure.Data.Repositories
{
    ///<inheritdoc cref="IPriceListCellRepository">
    public class PriceListCellRepository : BaseRepository, IPriceListCellRepository, IDisposable
    {
        public void CreatePriceListCells(List<PriceListCell> cells)
        {
            _dbContext.PriceListCells.AddRange(cells);
            _dbContext.SaveChanges();
        }
    }
}

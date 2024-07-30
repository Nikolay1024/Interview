using System.Collections.Generic;

namespace PriceListEditor2.Models
{
    /// <summary>
    /// Модель прайс-листов.
    /// </summary>
    public class PriceListsViewModel
    {
        /// <summary>
        /// Прайс-листы.
        /// </summary>
        public List<PriceListViewModal> PriceLists { get; set; } = new List<PriceListViewModal>();
    }
}
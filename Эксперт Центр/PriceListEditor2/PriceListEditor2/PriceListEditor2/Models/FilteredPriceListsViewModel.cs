using System.Collections.Generic;

namespace PriceListEditor2.Models
{
    public class FilteredPriceListsViewModel
    {
        public List<PriceListViewModal> Items { get; set; } = new List<PriceListViewModal>();
    }
}
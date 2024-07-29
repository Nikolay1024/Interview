using System.Collections.Generic;

namespace PriceListEditor2.Models
{
    public class DetailsPriceListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        
        public List<string> Columns { get; set; } = new List<string>();
        
        public List<PriceListProductViewModel> Products = new List<PriceListProductViewModel>();
    }
}
using System.Collections.Generic;

namespace PriceListEditor2.Models
{
    public class PriceListProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Code { get; set; }
        public List<GetPriceListColumnViewModel> Columns { get; set; } = new List<GetPriceListColumnViewModel>();
        public List<GetPriceListCellViewModel> Cells { get; set; } = new List<GetPriceListCellViewModel>();
    }
}
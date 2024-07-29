using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PriceListEditor2.Models
{
    public class CreatePriceListViewModel
    {
        [Display(Name = "Имя прайс-листа")]
        public string Name { get; set; } = string.Empty;
        
        public List<PriceListColumnViewModel> Columns { get; set; } = new List<PriceListColumnViewModel>();
    }
}
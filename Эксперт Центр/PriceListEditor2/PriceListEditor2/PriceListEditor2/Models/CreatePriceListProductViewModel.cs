using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PriceListEditor2.Models
{
    public class CreatePriceListProductViewModel
    {
        [Display(Name = "Имя товара")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Код товара")]
        public int? Code { get; set; }

        public int? PriceListId { get; set; }

        public List<PriceListColumnViewModel> Columns { get; set; } = new List<PriceListColumnViewModel>();
        
        public List<string> Cells { get; set; } = new List<string>();
    }
}
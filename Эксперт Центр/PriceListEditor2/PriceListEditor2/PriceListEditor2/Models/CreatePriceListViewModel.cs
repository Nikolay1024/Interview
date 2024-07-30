using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PriceListEditor2.Models
{
    /// <summary>
    /// Модель создания прайс-листа.
    /// </summary>
    public class CreatePriceListViewModel
    {
        /// <summary>
        /// Имя прайс-листа.
        /// </summary>
        [Display(Name = "Имя прайс-листа")]
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// Столбцы прайс-листа.
        /// </summary>
        public List<PriceListColumnViewModel> Columns { get; set; } = new List<PriceListColumnViewModel>();
    }
}
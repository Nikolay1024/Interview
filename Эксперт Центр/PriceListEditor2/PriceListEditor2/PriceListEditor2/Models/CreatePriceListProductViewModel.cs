using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PriceListEditor2.Models
{
    /// <summary>
    /// Модель создания товара прайс-листа.
    /// </summary>
    public class CreatePriceListProductViewModel
    {
        /// <summary>
        /// Имя товара.
        /// </summary>
        [Display(Name = "Имя товара")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Код товара.
        /// </summary>
        [Display(Name = "Код товара")]
        public int? Code { get; set; }

        /// <summary>
        /// Идентификатор прайс-листа.
        /// </summary>
        public int? PriceListId { get; set; }

        /// <summary>
        /// Столбцы прайс-листа.
        /// </summary>
        public List<PriceListColumnViewModel> Columns { get; set; } = new List<PriceListColumnViewModel>();

        /// <summary>
        /// Ячейки прайс-листа.
        /// </summary>
        public List<string> Cells { get; set; } = new List<string>();
    }
}
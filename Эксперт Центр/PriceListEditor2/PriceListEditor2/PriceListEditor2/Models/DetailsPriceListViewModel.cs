using System.Collections.Generic;

namespace PriceListEditor2.Models
{
    /// <summary>
    /// Модель подробностей прайс-листа.
    /// </summary>
    public class DetailsPriceListViewModel
    {
        /// <summary>
        /// Идентификатор прайс-листа.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя прайс-листа.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// Столбцы прайс-листа.
        /// </summary>
        public List<string> Columns { get; set; } = new List<string>();
        
        /// <summary>
        /// Товары прайс-листа
        /// </summary>
        public List<PriceListProductViewModel> Products = new List<PriceListProductViewModel>();
    }
}
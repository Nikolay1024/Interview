using System.Collections.Generic;

namespace PriceListEditor2.Models
{
    /// <summary>
    /// Модель товара прайс-листа.
    /// </summary>
    public class PriceListProductViewModel
    {
        /// <summary>
        /// Идентификатор прайс-листа.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя товара прайс-листа.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Код товара прайс-листа.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Столбцы прайс-листа.
        /// </summary>
        public List<GetPriceListColumnViewModel> Columns { get; set; } = new List<GetPriceListColumnViewModel>();

        /// <summary>
        /// Ячейки прайс-листа.
        /// </summary>
        public List<GetPriceListCellViewModel> Cells { get; set; } = new List<GetPriceListCellViewModel>();
    }
}
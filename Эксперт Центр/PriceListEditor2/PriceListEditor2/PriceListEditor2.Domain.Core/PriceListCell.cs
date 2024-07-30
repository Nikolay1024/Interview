using System.ComponentModel.DataAnnotations;

namespace PriceListEditor2.Domain.Core
{
    /// <summary>
    /// Ячейка прайс-листа.
    /// </summary>
    public class PriceListCell
    {
        /// <summary>
        /// Уникальный идентификатор ячейки
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Значение ячейки
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Товар
        /// </summary>
        public int PriceListProductId { get; set; }
        public PriceListProduct PriceListProduct { get; set; }

        /// <summary>
        /// Столбец
        /// </summary>
        public int PriceListColumnId { get; set; }
        public PriceListColumn PriceListColumn { get; set; }
    }
}

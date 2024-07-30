using PriceListEditor2.Domain.Core.Enums;

namespace PriceListEditor2.Models
{
    /// <summary>
    /// Модель столбца прайс-листа.
    /// </summary>
    public class PriceListColumnViewModel
    {
        /// <summary>
        /// Имя столбца прайс-листа.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Тип значения столбца прайс-листа.
        /// </summary>
        public PriceListColumnType Type { get; set; } = PriceListColumnType.Number;
    }
}
namespace PriceListEditor2.Models
{
    /// <summary>
    /// Модель ячеек прайс-листа.
    /// </summary>
    public class GetPriceListCellViewModel
    {
        /// <summary>
        /// Идентификатор столбца прайс-листа.
        /// </summary>
        public int ColumnId { get; set; }
        
        /// <summary>
        /// Значение ячейки прайс-листа.
        /// </summary>
        public string Value { get; set; }
    }
}
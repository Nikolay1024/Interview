namespace PriceListEditor2.Models
{
    /// <summary>
    /// Модель столбца прайс-листа.
    /// </summary>
    public class GetPriceListColumnViewModel
    {
        /// <summary>
        /// Идентификатор столбца прайс-диста.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя столбца прайс-листа.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
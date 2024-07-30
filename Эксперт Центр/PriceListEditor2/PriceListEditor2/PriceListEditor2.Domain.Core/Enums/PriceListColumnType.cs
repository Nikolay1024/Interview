using System.ComponentModel.DataAnnotations;

namespace PriceListEditor2.Domain.Core.Enums
{
    /// <summary>
    /// Тип значений столбца.
    /// </summary>
    public enum PriceListColumnType
    {
        [Display(Name = "Число")]
        Number,
        [Display(Name = "Однострочный текст")]
        String,
        [Display(Name = "Многострочныйтекст")]
        Text
    }
}
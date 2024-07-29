using PriceListEditor2.Domain.Core.Enums;

namespace PriceListEditor2.Models
{
    public class PriceListColumnViewModel
    {
        public string Name { get; set; } = string.Empty;
        public PriceListColumnType Type { get; set; } = PriceListColumnType.Number;
    }
}
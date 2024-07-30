using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PriceListEditor2.Domain.Core
{
    /// <summary>
    /// Товар прайс-листа.
    /// </summary>
    public class PriceListProduct
    {
        /// <summary>
        /// Уникальный идентификатор товара
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Имя товара
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Код товара
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Прайс-лист
        /// </summary>
        public int PriceListId { get; set; }
        public PriceList PriceList { get; set; }

        /// <summary>
        /// Ячейки товара
        /// </summary>
        public virtual ICollection<PriceListCell> PriceListCells { get; set; }
    }
}

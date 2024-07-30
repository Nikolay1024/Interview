using PriceListEditor2.Domain.Core.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PriceListEditor2.Domain.Core
{
    /// <summary>
    /// Колонка прайс-листа.
    /// </summary>
    public class PriceListColumn
    {
        /// <summary>
        /// Уникальный идентификатор столбца
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Имя столбца
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тип значений столбца
        /// </summary>
        public PriceListColumnType Type { get; set; }

        /// <summary>
        /// Прайс-лист
        /// </summary>
        public int PriceListId { get; set; }
        public PriceList PriceList { get; set; }

        /// <summary>
        /// Ячейки столбца
        /// </summary>
        public virtual ICollection<PriceListCell> PriceListCells { get; set; }
    }
}

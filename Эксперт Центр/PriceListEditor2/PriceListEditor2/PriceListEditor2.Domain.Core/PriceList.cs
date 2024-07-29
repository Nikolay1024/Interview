using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PriceListEditor2.Domain.Core
{
    /// <summary>
    /// Прайс-лист
    /// </summary>
    public class PriceList
    {
        /// <summary>
        /// Уникальный идентификатор прайс-листа
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Имя прайс-листа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата и время создания прайс-листа
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Продукты прайс-листа
        /// </summary>
        public virtual ICollection<PriceListProduct> PriceListProducts { get; set; }

        /// <summary>
        /// Столбцы прайс-листа
        /// </summary>
        public virtual ICollection<PriceListColumn> PriceListColumns { get; set; }
    }
}

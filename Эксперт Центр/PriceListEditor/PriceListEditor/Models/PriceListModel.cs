using DataAccessLayer.EntityFramework;
using System.Collections.Generic;

namespace PriceListEditor.Models
{
    public class PriceListModel
    {
        public PriceList PriceList { get; set; }
        public List<Column> Columns { get; set; }
        public List<Cell> Cells { get; set; }
    }
}
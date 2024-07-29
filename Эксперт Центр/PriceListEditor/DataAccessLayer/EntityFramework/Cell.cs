namespace DataAccessLayer.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cell")]
    public partial class Cell
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Value { get; set; }

        public int ColumnId { get; set; }

        public int RowId { get; set; }

        public virtual Column Column { get; set; }
    }
}

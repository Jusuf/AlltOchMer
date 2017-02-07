namespace WU15.AlltOchMer.Data.Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductList")]
    public partial class ProductListView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(150)]
        public string ProductName { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal? Price { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(150)]
        public string PriceName { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime? ValidFrom { get; set; }
    }
}

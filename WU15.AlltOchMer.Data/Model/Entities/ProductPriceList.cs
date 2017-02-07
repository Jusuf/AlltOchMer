namespace WU15.AlltOchMer.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductPriceList")]
    public partial class ProductPriceList
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PriceListId { get; set; }

        public decimal Price { get; set; }

        public virtual PriceList PriceList { get; set; }

        public virtual Product Product { get; set; }
    }
}

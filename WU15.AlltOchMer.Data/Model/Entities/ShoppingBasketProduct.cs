namespace WU15.AlltOchMer.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShoppingBasketProduct")]
    public partial class ShoppingBasketProduct
    {
        [Key]
        [Column(Order = 0)]
        public Guid ShoppingBasketGUID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public virtual Product Product { get; set; }

        public virtual ShoppingBasket ShoppingBasket { get; set; }
    }
}

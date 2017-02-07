namespace WU15.AlltOchMer.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShoppingBasket")]
    public partial class ShoppingBasket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShoppingBasket()
        {
            ShoppingBasketProducts = new HashSet<ShoppingBasketProduct>();
        }

        [Key]
        public Guid GUID { get; set; }

        public DateTime CreatedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingBasketProduct> ShoppingBasketProducts { get; set; }
    }
}

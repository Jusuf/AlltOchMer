using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WU15.AlltOchMer.Data;

namespace WU15.AlltOchMer.Web.Model.ProductModel
{
    public class ProductDetailViewModel
    {
        public int Id { get; set; }

        public string AricleNumber { get; set; }

        public string Name { get; set; }

        public decimal? Price { get; set; }

        public string PriceName { get; set; }

        public DateTime? ValidFrom { get; set; }
    }
}
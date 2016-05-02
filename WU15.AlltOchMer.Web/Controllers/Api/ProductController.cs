using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WU15.AlltOchMer.Data;
using WU15.AlltOchMer.Data.Model.Entities;
using WU15.AlltOchMer.Service.Services;
using WU15.AlltOchMer.Web.Model.ProductModel;

namespace WU15.AlltOchMer.Web.Controllers.Api
{
    public class ProductController : ApiController
    {
        private IProductService productService = new ProductService();

        public IEnumerable<ProductList> Get()
        {
            return productService.GetProducts();
        }
        public IHttpActionResult Get(int id)
        {
            
            var p = productService.GetProduct(id);
            
            if (p == null)
                return NotFound();
            var productResult = new ProductViewModel()
            {
                Id = p.ProductId,
                AricleNumber = p.ArticleNumber,
                Name = p.ProductName,
                PriceName = p.PriceName,
                Price = p.Price,
                ValidFrom = p.ValidFrom 
            };
            return Ok(productResult);
        }

    }
}

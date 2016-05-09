using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;
using System.Web.OData;
using WU15.AlltOchMer.Data;
using WU15.AlltOchMer.Data.Model.Entities;
using WU15.AlltOchMer.Data.Repository;
using WU15.AlltOchMer.Data.Repository.EntityRepositorys;
//using WU15.AlltOchMer.Data.Repository.EntityRepositorys;

//using WU15.AlltOchMer.Service.Services;
using WU15.AlltOchMer.Web.Model.ProductModel;

namespace WU15.AlltOchMer.Web.Controllers.Api
{

    public class ProductController : ApiController
    {
        //private IProductRepository productRepository;

        private IProductListRepository productListRepository;

        public ProductController()
        {
            var alltOchMerDataContext = new AlltOchMerDataContext("AlltOchMerDbConnectionString");
            this.productListRepository = new ProductListRepository(alltOchMerDataContext);
        }
        public ProductController(IProductListRepository productListRepository)
        {
            this.productListRepository = productListRepository;
        }

        [HttpGet]
        public List<ProductListView> GetAllProducts()
        {
            var productList = this.productListRepository.GetAll().ToList();
            return productList;
        }

        //[HttpGet][EnableQuery]
        //public IQueryable<Product> Get()
        //{
        //    var allProducts = this.productListRepository.GetAll().AsQueryable();
            
            //var products = allProducts.Where(p => p.Categories == p.Categories.)
            //List<ProductViewModel> productList = new List<ProductViewModel>();

            //var result = allProducts.Select(p => new ProductViewModel()
            //{
            //    Id = p.Id,
            //    Name = p.Name,
            //    AricleNumber = "0",
            //    Price = 0,
            //    PriceName = "Gratis",
            //    ValidFrom = new DateTime()
            //}).ToList();
        //    return allProducts;
            
        //}

        //public IHttpActionResult Get(int id)
        //{
            
        //    var p = productService.GetProduct(id);
            
        //    if (p == null)
        //        return NotFound();
        //    var productResult = new ProductViewModel()
        //    {
        //        Id = p.ProductId,
        //        Name = p.ProductName,
        //        PriceName = p.PriceName,
        //        Price = p.Price,
        //        ValidFrom = p.ValidFrom 
        //    };
        //    return Ok(productResult);
        //}

    }
}

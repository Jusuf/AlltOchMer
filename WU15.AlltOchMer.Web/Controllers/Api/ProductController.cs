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
        private IProductRepository productRepository;

        public ProductController()
        {
            var alltOchMerDataContext = new AlltOchMerDataContext("AlltOchMerDbConnectionString");
            this.productListRepository = new ProductListRepository(alltOchMerDataContext);
            this.productRepository = new ProductRepository(alltOchMerDataContext);
        }
        public ProductController(IProductListRepository productListRepository, IProductRepository productRepository)
        {
            this.productListRepository = productListRepository;
            this.productRepository = productRepository;
        }

        [HttpGet]
        public List<ProductListView> AllProducts()
        {
            var productList = this.productListRepository.GetAll().ToList();
            return productList;
        }

        //public IHttpActionResult Get(int id)
        //{

        //    var product = this.productRepository.GetById(id);

        //    if (product == null)
        //        return NotFound();

        //    return Ok(product);
        //}

        [HttpGet]
        public IHttpActionResult ProductDetails(int id)
        {
            DateTime now = DateTime.Now;
            AlltOchMerDataContext db = new AlltOchMerDataContext("AlltOchMerDbConnectionString");
            var product = from p in db.Products
                          join price in db.ProductPriceLists
                          on p.Id equals price.ProductId

                          join pl in db.PriceLists
                          on price.PriceListId equals pl.Id
                          
                          join description in db.ProductDescriptions
                          on p.Id equals description.ProductId
                          
                          where p.Id == id
                          where description.LanguageId == 1
                          where pl.ValidFrom >= now
                          
                          select p;

            return Ok(product);
            
            //if (product == null)
            //    return NotFound();
            //return Ok(product);
        }

    }
}

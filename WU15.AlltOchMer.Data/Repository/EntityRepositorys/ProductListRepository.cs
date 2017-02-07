using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WU15.AlltOchMer.Data.Model.Entities;

namespace WU15.AlltOchMer.Data.Repository.EntityRepositorys
{
    public class ProductListRepository : MainRepository<ProductListView, int>, IProductListRepository
    {
        public ProductListRepository(DbContext context) : base(context) { }

        public IEnumerable<ProductListView> FindByName(string name)
        {
            return GetAll()
                .Where(x => x.ProductName.ToLowerInvariant()
                .Contains(name.ToLowerInvariant()));
        }
    }
}
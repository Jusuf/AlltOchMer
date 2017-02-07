using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WU15.AlltOchMer.Data.Repository.EntityRepositorys
{
    public class ProductRepository : MainRepository<Product, int>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context) { }

        public IEnumerable<Product> FindByName(string name)
        {
            return GetAll()
                .Where(x => x.Name.ToLowerInvariant()
                .Contains(name.ToLowerInvariant()));
        }
    }
}
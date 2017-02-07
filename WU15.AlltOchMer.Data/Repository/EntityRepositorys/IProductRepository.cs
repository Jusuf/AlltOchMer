using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WU15.AlltOchMer.Data.Repository.EntityRepositorys
{
    public interface IProductRepository : IMainRepository<Product, int>
    {
        IEnumerable<Product> FindByName(string name);
    }
}
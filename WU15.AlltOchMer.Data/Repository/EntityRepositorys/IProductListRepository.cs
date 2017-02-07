using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WU15.AlltOchMer.Data.Model.Entities;

namespace WU15.AlltOchMer.Data.Repository.EntityRepositorys
{
    public interface IProductListRepository : IMainRepository<ProductListView, int>
    {
        IEnumerable<ProductListView> FindByName(string name);
    }
}
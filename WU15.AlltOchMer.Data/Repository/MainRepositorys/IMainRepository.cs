using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace WU15.AlltOchMer.Data.Repository
{
    public interface IMainRepository<TEntity, in Tkey> : IDisposable
    {
        IQueryable<TEntity> GetAll();

        TEntity GetById(Tkey id);

        void Insert(TEntity entity);

        void Delete(Tkey id);

        void Update(TEntity entity);

        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);

        //IQueryable<TEntity> Query();

        void Save();
        
    }
}
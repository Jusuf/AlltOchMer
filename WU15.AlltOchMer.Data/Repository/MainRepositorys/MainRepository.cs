﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace WU15.AlltOchMer.Data.Repository
{
    public class MainRepository<TEntity, Tkey> : IMainRepository<TEntity, Tkey> where TEntity : class
    {
        private readonly DbContext context;

        private readonly DbSet<TEntity> dbSet;

        public MainRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList().AsQueryable();
        }

        public TEntity GetById(Tkey id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(Tkey id)
        {
            var entityToRemove = dbSet.Find(id);

            dbSet.Remove(entityToRemove);
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);

            context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

    }
}
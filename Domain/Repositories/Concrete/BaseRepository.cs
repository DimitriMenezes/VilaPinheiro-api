using Domain.Context;
using Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories.Concrete
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        internal readonly ModelContext context;
        internal DbSet<TEntity> dbSet;

        public BaseRepository()
        {
            this.context = new ModelContext();
            this.dbSet = context.Set<TEntity>();
        }

        public void Delete(int id)
        {
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public System.Linq.IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }

        public TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
            context.SaveChanges();
        }
    }
}

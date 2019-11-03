using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repositories.Abstract
{
    public interface IBaseRepository <TEntity>
    {
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.Abstract
{
    public interface IRepository<TEntity, TId> where TEntity : class
    {
        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        TEntity GetById(TId id);

        List<TEntity> GetAll();

        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter);

        abstract List<TEntity> GetAllWithRelations();

        abstract List<TEntity> GetAllWithRelations(Expression<Func<TEntity, bool>> filter);

        void SaveChanges();
    }
}
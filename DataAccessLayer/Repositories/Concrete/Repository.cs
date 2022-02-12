using DataAccessLayer.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.Concrete
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        protected DbSet<TEntity> dbSet;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            dbSet = _applicationDbContext.Set<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            SaveChanges();
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
            SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            SaveChanges();
        }

        public TEntity GetById(int id) =>
            dbSet.Find(id);

        public TEntity GetById(string id) =>
            dbSet.Find(id);

        public List<TEntity> GetAll() =>
            dbSet.ToList();

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter) =>
            dbSet.Where(filter).ToList();

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }

        public virtual TEntity GetByIdWithRelations(int id) { return null; }

        public virtual TEntity GetByIdWithRelations(string id) { return null; }

        public abstract List<TEntity> GetAllWithRelations();

        public abstract List<TEntity> GetAllWithRelations(Expression<Func<TEntity, bool>> filter);

    }
}
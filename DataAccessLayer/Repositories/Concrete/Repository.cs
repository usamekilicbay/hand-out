using DataAccessLayer.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.Concrete
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        protected DbSet<T> dbSet;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            dbSet = _applicationDbContext.Set<T>();
        }

        public void Insert(T p)
        {
            dbSet.Add(p);
            SaveChanges();
        }

        public void Update(T p)
        {
            dbSet.Update(p);
            SaveChanges();
        }

        public void Delete(T p)
        {
            dbSet.Remove(p);
            SaveChanges();
        }

        public T GetById(int id) =>
            dbSet.Find(id);

        public T GetById(string id) =>
            dbSet.Find(id);

        public List<T> GetAll() =>
            dbSet.ToList();

        public List<T> GetAll(Expression<Func<T, bool>> filter) => 
            dbSet.Where(filter).ToList();

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
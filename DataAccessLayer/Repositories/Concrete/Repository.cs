using DataAccessLayer.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext _dbContext;
        private DbSet<T> _dbSet;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public void Delete(T p)
        {
            _dbSet.Remove(p);
            _dbContext.SaveChanges();
        }

        public List<T> GetAll() =>
            _dbSet.ToList();

        public List<T> GetAll(Expression<Func<T, bool>> filter) => 
            _dbSet.Where(filter).ToList();

        public T GetByID(int id) => 
            _dbSet.Find(id);

        public void Insert(T p)
        {
            _dbSet.Add(p);
            _dbContext.SaveChanges();
        }

        public void Update(T p)
        {
            _dbContext.SaveChanges();
        }
    }
}

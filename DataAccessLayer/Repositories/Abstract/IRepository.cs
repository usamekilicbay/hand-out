using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.Abstract
{
    public interface IRepository<T> where T : class
    {
        void Insert(T p);

        void Update(T p);
        
        void Delete(T p);

        T GetByID(int id);
        
        List<T> GetAll();

        List<T> GetAll(Expression<Func<T, bool>> filter);

        void SaveChanges();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Abstract
{
    public interface IRepository<T> where T : class
    {
        void Insert(T p);

        void Delete(T p);
        
        T GetByID(int id);
        
        List<T> GetAll();

        List<T> GetAll(Expression<Func<T, bool>> filter);
        
        void Update(T p);
    }
}
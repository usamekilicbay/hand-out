using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private Context _context = new Context();
        private DbSet<T> _entity;

        public GenericRepository()
        {
            _entity = _context.Set<T>();
        }

        public void Create(T p)
        {
            _entity.Add(p);
            _context.SaveChanges();
        }

        public void Delete(T p)
        {
            _entity.Remove(p);
            _context.SaveChanges();
        }

        public List<T> List() =>
            _entity.ToList();

        public List<T> List(Expression<Func<T, bool>> filter) =>
            _entity.Where(filter).ToList();

        public void Update(T p)
        {
            _context.SaveChanges();
        }
    }
}

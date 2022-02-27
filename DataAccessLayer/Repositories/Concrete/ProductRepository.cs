using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override List<Product> GetAllWithRelations()
            => dbSet
                .Include(p => p.Category)
                .Include(p => p.Grantor)
                .Include(p => p.Chats)
                .ToList();

        public override List<Product> GetAllWithRelations(Expression<Func<Product, bool>> filter)
        {
            return dbSet
                .Where(filter)
                .Include(p => p.Category)
                .Include(p => p.Grantor)
                .Include(p => p.Chats)
                .ToList();
        }
    }
}
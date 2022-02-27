using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.Concrete
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override List<Category> GetAllWithRelations()
        {
            throw new System.NotImplementedException();
        }

        public override List<Category> GetAllWithRelations(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}

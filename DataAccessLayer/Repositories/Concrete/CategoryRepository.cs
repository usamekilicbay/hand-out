using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories.Concrete
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}

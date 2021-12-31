using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}

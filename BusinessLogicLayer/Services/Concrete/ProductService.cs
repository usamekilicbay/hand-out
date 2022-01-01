using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using DataAccessLayer;
using DataAccessLayer.Repositories.Concrete;
using EntityLayer.Concrete;

namespace BusinessLogicLayer.Services.Concrete
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(ApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper)
        {
            Repository = new ProductRepository(applicationDbContext);
        }
    }
}

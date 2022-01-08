using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using DataAccessLayer;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Concrete;
using EntityLayer.Concrete;

namespace BusinessLogicLayer.Services.Concrete
{
    public class ProductService : Service<Product>, IProductService
    {
        public IProductRepository ProductRepository { get; set; }

        public ProductService(ApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper)
        {
            ProductRepository = new ProductRepository(applicationDbContext);
            Repository = ProductRepository;
        }
    }
}

using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using BusinessLogicLayer.Services.Concrete;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryService CategoryService { get; private set; }

        public IProductService ProductService { get; private set; }

        public IUserService UserService { get; private set; }

        public UnitOfWork(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            CategoryService = new CategoryService(applicationDbContext, mapper);
            ProductService = new ProductService(applicationDbContext, mapper);
            UserService = new UserService(applicationDbContext, mapper);
        }
    }
}

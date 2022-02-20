using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using BusinessLogicLayer.Services.Concrete;
using DataAccessLayer;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogicLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryService CategoryService { get; private set; }
        
        public IMessageService MessageService { get; private set; }

        public IProductService ProductService { get; private set; }

        public IUserService UserService { get; private set; }


        public UnitOfWork(ApplicationDbContext applicationDbContext, IMapper mapper,
            UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            CategoryService = new CategoryService(applicationDbContext, mapper, this);
            MessageService = new MessageService(applicationDbContext, mapper, this);
            ProductService = new ProductService(applicationDbContext, mapper, this);
            UserService = new UserService(applicationDbContext, mapper, userManager, signInManager, httpContextAccessor, this);
        }
    }
}
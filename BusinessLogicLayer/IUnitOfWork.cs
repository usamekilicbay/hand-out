using BusinessLogicLayer.Services.Abstract;

namespace BusinessLogicLayer
{
    public interface IUnitOfWork
    {
        public ICategoryService CategoryService { get; }
        public IMessageService MessageService { get; }
        public IProductService ProductService { get; }
        public IUserService UserService { get; }
    }
}
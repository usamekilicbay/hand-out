using BusinessLogicLayer.Services.Abstract;

namespace BusinessLogicLayer
{
    public interface IUnitOfWork
    {
        ICategoryService CategoryService { get; }
        IChatService ChatService { get; }
        IMessageService MessageService { get; }
        IProductService ProductService { get; }
        IUserService UserService { get; }
    }
}
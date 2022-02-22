using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;

namespace BusinessLogicLayer.Services.Abstract
{
    public interface IChatService : IService<Chat>
    {
        IChatRepository ChatRepository { get; set; }
    }
}
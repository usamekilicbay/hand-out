using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories.Abstract
{
    public interface IChatRepository : IRepository<Chat>
    {
        new Chat Insert(Chat chat);
    }
}

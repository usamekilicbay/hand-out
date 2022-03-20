using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories.Abstract
{
    public interface IChatRepository : IRepository<Chat, string>
    {
        new Chat Insert(Chat chat);
    }
}
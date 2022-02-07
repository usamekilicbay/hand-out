using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories.Concrete
{
    class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}

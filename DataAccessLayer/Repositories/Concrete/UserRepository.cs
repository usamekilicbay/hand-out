using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories.Concrete
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

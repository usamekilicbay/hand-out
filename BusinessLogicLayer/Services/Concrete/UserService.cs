using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using DataAccessLayer;
using DataAccessLayer.Repositories.Concrete;
using EntityLayer.Concrete;

namespace BusinessLogicLayer.Services.Concrete
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(ApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper)
        {
            Repository = new UserRepository(applicationDbContext);
        }
    }
}

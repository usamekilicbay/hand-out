using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using DataAccessLayer;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogicLayer.Services.Concrete
{
    public class UserService : Service<User>, IUserService
    {
        public IUserRepository UserRepository { get; set; }

        public UserService(ApplicationDbContext applicationDbContext, IMapper mapper,
            UserManager<User> userManager, SignInManager<User> signInManager,
            IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        {
            UserRepository = new UserRepository(applicationDbContext, userManager, signInManager, httpContextAccessor);
            Repository = UserRepository;
        }

        public string GetCurrentUserId() =>
            UserRepository.GetUserId();


        public ViewModel GetCurrentUserDetails<ViewModel>()
        {
            User user = UserRepository.GetUserDetails();

            return mapper.Map<ViewModel>(user);
        }

        public SignInResult PasswordSignIn(string userName, string password, bool isPersistent, bool islockoutOnFailure) => 
            UserRepository.PasswordSignIn(userName, password, isPersistent, islockoutOnFailure);

        public IdentityResult SignUp<ViewModel>(ViewModel viewModel, string password)
        {
            User user = mapper.Map<User>(viewModel);

            return UserRepository.SignUp(user, password);
        }
    }
}

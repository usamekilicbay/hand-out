using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using DataAccessLayer;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BusinessLogicLayer.Services.Concrete
{
    public class UserService : Service<User>, IUserService
    {
        public IUserRepository UserRepository { get; set; }

        public UserService(ApplicationDbContext applicationDbContext, IMapper mapper,
            UserManager<User> userManager, SignInManager<User> signInManager)
            : base(mapper)
        {
            UserRepository = new UserRepository(applicationDbContext, userManager, signInManager);
            Repository = UserRepository;
        }

        public ViewModel GetUserDetails<ViewModel>(ClaimsPrincipal claimsPrincipal)
        {
            User user = UserRepository.GetUserDetails(claimsPrincipal);

            return mapper.Map<ViewModel>(user);
        }

        public SignInResult PasswordSignIn(string userName, string password, bool isPersistent, bool islockoutOnFailure)
        {
            return UserRepository.PasswordSignIn(userName, password, isPersistent, islockoutOnFailure);
        }

        public IdentityResult SignUp<ViewModel>(ViewModel viewModel, string password)
        {
            User user = mapper.Map<User>(viewModel);

            return UserRepository.SignUp(user, password);
        }
    }
}

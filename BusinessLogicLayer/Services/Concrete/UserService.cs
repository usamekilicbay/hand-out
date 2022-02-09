using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using DataAccessLayer;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Concrete;
using DataLayer.User;
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
            UserRepository.GetCurrentUserId();

        public DetailsUserDTO GetCurrentUserDetails()
        {
            User user = UserRepository.GetCurrentUser();

            return mapper.Map<DetailsUserDTO>(user);
        }

        public SignInResult PasswordSignIn(PasswordSignInUserDTO passwordSignInUserDTO) =>
            UserRepository.PasswordSignIn(passwordSignInUserDTO);

        public IdentityResult SignUp(SignUpUserDTO signUpUserDTO)
        {
            User user = mapper.Map<User>(signUpUserDTO);

            return UserRepository.SignUp(user, signUpUserDTO.Password);
        }
    }
}
using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DataAccessLayer.Repositories.Concrete
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserManager<User> UserManager { get; set; }
        public SignInManager<User> SignInManager { get; set; }

        public UserRepository(ApplicationDbContext dbContext,
            UserManager<User> userManager, SignInManager<User> signInManager) : base(dbContext)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public User GetUserDetails(ClaimsPrincipal claimsPrincipal)
        {
            return UserManager.FindByIdAsync(UserManager.GetUserId(claimsPrincipal)).Result;
        }

        public SignInResult PasswordSignIn(string userName, string password, bool isPersistent, bool lockoutOnFailure = false)
        {
            return SignInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure).Result;
        }

        public IdentityResult SignUp(User user, string password)
        {
            return UserManager.CreateAsync(user, password).Result;
        }
    }
}

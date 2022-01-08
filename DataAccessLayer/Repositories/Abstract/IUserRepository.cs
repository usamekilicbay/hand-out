using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DataAccessLayer.Repositories.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        public UserManager<User> UserManager { get; set; }
        public SignInManager<User> SignInManager { get; set; }

        public User GetUserDetails(ClaimsPrincipal id);
        public SignInResult PasswordSignIn(string userName, string password, bool isPersistent, bool lockoutOnFailure = false);
        public IdentityResult SignUp(User user, string password);
    }
}

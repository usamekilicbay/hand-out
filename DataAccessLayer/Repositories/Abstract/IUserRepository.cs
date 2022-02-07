using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Repositories.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        public UserManager<User> UserManager { get; set; }
        public SignInManager<User> SignInManager { get; set; }

        public string GetCurrentUserId();
        public User GetCurrentUser();
        public SignInResult PasswordSignIn(string userName, string password, bool isPersistent, bool lockoutOnFailure = false);
        public IdentityResult SignUp(User user, string password);
    }
}

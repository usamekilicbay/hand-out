using DataLayer.User;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Repositories.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        UserManager<User> UserManager { get; set; }
        SignInManager<User> SignInManager { get; set; }
        IHttpContextAccessor HttpContextAccessor { get; set; }

        public User GetUser(string userId);
        string GetCurrentUserId();
        User GetCurrentUser();
        SignInResult PasswordSignIn(PasswordSignInUserDTO passwordSignInUserDTO);
        IdentityResult SignUp(User user, string password);
        void SignOut();
    }
}
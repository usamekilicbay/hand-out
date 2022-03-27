using DataLayer.User;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Abstract
{
    public interface IUserRepository : IRepository<User, string>
    {
        UserManager<User> UserManager { get; set; }
        SignInManager<User> SignInManager { get; set; }
        IHttpContextAccessor HttpContextAccessor { get; set; }

        User GetUser(string userId);
        string GetCurrentUserId();
        User GetCurrentUser();
        Task<IdentityResult> UpdateUserAsync(User user);
        SignInResult PasswordSignIn(PasswordSignInUserDTO passwordSignInUserDTO);
        IdentityResult SignUp(User user, string password);
        void SignOut();
    }
}
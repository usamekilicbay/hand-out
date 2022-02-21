using DataLayer.User;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Repositories.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        public UserManager<User> UserManager { get; set; }
        public SignInManager<User> SignInManager { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public string GetCurrentUserId();
        public User GetCurrentUser();
        public SignInResult PasswordSignIn(PasswordSignInUserDTO passwordSignInUserDTO);
        public IdentityResult SignUp(User user, string password);
        public void SignOut();
        public User GetByIdWithMessages(string id);
        public User GetByIdWithMessages(string id, int productId);
    }
}
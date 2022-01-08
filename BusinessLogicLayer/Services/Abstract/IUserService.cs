using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BusinessLogicLayer.Services.Abstract
{
    public interface IUserService : IService<User>
    {
        public IUserRepository UserRepository { get; set; }

        public ViewModel GetUserDetails<ViewModel>(ClaimsPrincipal claimsPrincipal);
        public IdentityResult SignUp<ViewModel>(ViewModel viewModel, string password);
        public SignInResult PasswordSignIn(string userName, string password, bool isPersistent, bool lockoutOnFailure = false);
    }
}

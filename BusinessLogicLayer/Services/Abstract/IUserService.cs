using DataAccessLayer.Repositories.Abstract;
using DataLayer.User;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogicLayer.Services.Abstract
{
    public interface IUserService : IService<User>
    {
        IUserRepository UserRepository { get; set; }

        string GetCurrentUserId();
        DetailsUserDTO GetCurrentUserDetails();
        void UpdateProfilePhoto(IFormFile photo);
        SignInResult PasswordSignIn(PasswordSignInUserDTO passwordSignInUserDTO);
        IdentityResult SignUp(SignUpUserDTO signUpUserDTO);
        void SignOut();
    }
}
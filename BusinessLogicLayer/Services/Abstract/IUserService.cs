using DataAccessLayer.Repositories.Abstract;
using DataLayer.Shared;
using DataLayer.User;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogicLayer.Services.Abstract
{
    public interface IUserService : IService<User, string>
    {
        IUserRepository UserRepository { get; set; }

        DetailsUserDTO GetUserDetails(string userId);
        ProfileDTO GetUserProfile(string userId);
        string GetCurrentUserId();
        DetailsUserDTO GetCurrentUserDetails();
        ProfileDTO GetCurrentUserProfile();
        void UpdateProfilePhoto(IFormFile photo);
        SignInResult PasswordSignIn(PasswordSignInUserDTO passwordSignInUserDTO);
        IdentityResult SignUp(SignUpUserDTO signUpUserDTO);
        void SignOut();
    }
}
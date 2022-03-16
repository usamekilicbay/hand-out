using DataAccessLayer.Repositories.Abstract;
using DataLayer.Shared;
using DataLayer.User;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogicLayer.Services.Abstract
{
    public interface IUserService : IService<User>
    {
        IUserRepository UserRepository { get; set; }

        public DetailsUserDTO GetUserDetails(string userId);
        public ProfileDTO GetUserProfile(string userId);
        string GetCurrentUserId();
        DetailsUserDTO GetCurrentUserDetails();
        public ProfileDTO GetCurrentUserProfile();
        void UpdateProfilePhoto(IFormFile photo);
        SignInResult PasswordSignIn(PasswordSignInUserDTO passwordSignInUserDTO);
        IdentityResult SignUp(SignUpUserDTO signUpUserDTO);
        void SignOut();
    }
}
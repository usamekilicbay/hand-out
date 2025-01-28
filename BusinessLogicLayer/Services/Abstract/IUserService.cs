using DataAccessLayer.Repositories.Abstract;
using DataLayer.General.User;
using DataLayer.Shared;
using DataLayer.User;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

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
        Task<IdentityResult> UpdateUserAsync<T>(T updateProductDTO, string id);
        Task<SignInResult> PasswordSignIn(PasswordSignInUserDTO passwordSignInUserDTO);
        IdentityResult SignUp(SignUpUserDTO signUpUserDTO);
        void SignOut();
    }
}
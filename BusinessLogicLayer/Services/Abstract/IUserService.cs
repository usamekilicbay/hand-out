using DataAccessLayer.Repositories.Abstract;
using DataLayer.User;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogicLayer.Services.Abstract
{
    public interface IUserService : IService<User>
    {
        public IUserRepository UserRepository { get; set; }

        public string GetCurrentUserId();
        public DetailsUserDTO GetCurrentUserDetails();
        public SignInResult PasswordSignIn(PasswordSignInUserDTO passwordSignInUserDTO);
        public IdentityResult SignUp(SignUpUserDTO signUpUserDTO);
    }
}
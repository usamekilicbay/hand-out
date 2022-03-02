using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using DataAccessLayer;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Concrete;
using DataLayer.User;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Sidekick.NET;
using Sidekick.NET.Constant;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services.Concrete
{
    public class UserService : Service<User>, IUserService
    {
        public IUserRepository UserRepository { get; set; }

        public UserService(ApplicationDbContext applicationDbContext, IMapper mapper,
            UserManager<User> userManager, SignInManager<User> signInManager,
            IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        {
            UserRepository = new UserRepository(applicationDbContext, userManager, signInManager, httpContextAccessor);
            Repository = UserRepository;
        }

        public string GetCurrentUserId() =>
            UserRepository.GetCurrentUserId();

        public DetailsUserDTO GetCurrentUserDetails()
        {
            User user = UserRepository.GetCurrentUser();

            return mapper.Map<DetailsUserDTO>(user);
        }

        public void UpdateProfilePhoto(IFormFile photo)
        {
            User user = UserRepository.GetCurrentUser();

            FileOperations.RemoveOldPhotos(user.ProfilePhotoURL, Path.PROFILE_IMAGES);

            user.ProfilePhotoURL = FileOperations.SavePhoto(photo, Path.PROFILE_IMAGES);

            UserRepository.Update(user);
        }

        #region Authentication
        public SignInResult PasswordSignIn(PasswordSignInUserDTO passwordSignInUserDTO) =>
            UserRepository.PasswordSignIn(passwordSignInUserDTO);

        public IdentityResult SignUp(SignUpUserDTO signUpUserDTO)
        {
            User user = mapper.Map<User>(signUpUserDTO);

            return UserRepository.SignUp(user, signUpUserDTO.Password);
        }

        public void SignOut()
        {
            UserRepository.SignOut();
        }
        #endregion
    }
}
using BusinessLogicLayer.Services.Abstract;
using hand_out.Models;
using DataLayer.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using BusinessLogicLayer;
using DataLayer.Category;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;
using hand_out.Models.ViewModels.User;
using hand_out.Models.ViewModels.Shared;
using hand_out.Models.ViewModels.Product;
using DataLayer.General.User;
using Microsoft.AspNetCore.Http;
using DataLayer.Shared;

namespace hand_out.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userService = unitOfWork.UserService;
            _mapper = mapper;
        }

        [Authorize()]
        public IActionResult Details(string id)
        {
            ProfileViewModel profileViewModel;
            ProfileDTO profileDTO;

            if (string.IsNullOrEmpty(id) || id.Equals(_userService.GetCurrentUserId()))
            {
                profileDTO = _userService.GetCurrentUserProfile();
                ViewBag.IsOwnProfile = true;
                ViewBag.Categories = new SelectList(_unitOfWork.CategoryService.GetAll<DropdownCategoryDTO>(), "Id", "Name");
            }
            else
            {
                profileDTO = _userService.GetUserProfile(id);
                ViewBag.IsOwnProfile = false;
            }

            profileViewModel = new(
                detailsUserViewModel: _mapper.Map<DetailsUserViewModel>(profileDTO.DetailsUserDTO),
                listProductViewModels: _mapper.Map<List<ListProductViewModel>>(profileDTO.ListProductDTOs));

            return View(profileViewModel);
        }

        public IActionResult Edit()
        {
            return View(new DetailsUserViewModel
            {
                //Name = "Usame Kilicbay",
                //Mail = "usame.kilicbay@protonmail.com",
                //Address = "Turkey",
                //ProfilePicURL = "https://media-exp1.licdn.com/dms/image/C5603AQEoe9--htofaA/profile-displayphoto-shrink_800_800/0/1576480070508?e=1644451200&v=beta&t=UBn25UjZZOMD16JzYKJtWGukEhFohlRe59w462JZy18",
            });
        }

        public void UpdateProfilePhoto(IFormFile photo)
        {
            _userService.UpdateProfilePhoto(photo);
        }

        public void Update(UpdateUserDTO updateUserDTO)
        {
            _userService.Update(updateUserDTO, _unitOfWork.UserService.GetCurrentUserId());
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpUserViewModel signUpUserViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            IdentityResult identityResult = _userService.SignUp(_mapper.Map<SignUpUserDTO>(signUpUserViewModel));

            if (!identityResult.Succeeded)
            {
                List<IdentityError> errors = identityResult.Errors.ToList();
                errors.ForEach(e => ModelState.AddModelError(e.Code, e.Code));
                return View();
            }

            return RedirectToAction("Details");
        }


        #region Authentication
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(PasswordSignInUserViewModel signInUserViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            SignInResult signInResult = _userService.PasswordSignIn(_mapper.Map<PasswordSignInUserDTO>(signInUserViewModel));

            if (!signInResult.Succeeded)
            {
                return View();
            }

            return RedirectToAction("Details");
        }

        public new IActionResult SignOut()
        {
            _userService.SignOut();
            return RedirectToAction("SignIn");
        }

        public IActionResult Authenticate()
        {
            return RedirectToAction("Details");
        }
        #endregion
    }
}
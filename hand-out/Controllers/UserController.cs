using BusinessLogicLayer.Services.Abstract;
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
using System.Threading.Tasks;

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

        public void UpdateProfilePhoto(IFormFile photo)
        {
            _userService.UpdateProfilePhoto(photo);
        }

        public void UpdateUserName(string newUserName)
        {
            UpdateUserDTO updateUserDTO = _userService.GetById<UpdateUserDTO>(_userService.GetCurrentUserId());
            updateUserDTO.UserName = newUserName;
            Update(updateUserDTO);
        }

        public void UpdateAddress(string newAddress)
        {
            UpdateUserDTO updateUserDTO = _userService.GetById<UpdateUserDTO>(_userService.GetCurrentUserId());
            updateUserDTO.Address = newAddress;
            Update(updateUserDTO);
        }

        public void Update(UpdateUserDTO updateUserDTO)
        {
           _userService.UpdateUserAsync(updateUserDTO, _userService.GetCurrentUserId());
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
        public async Task<IActionResult> SignIn(PasswordSignInUserViewModel signInUserViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            SignInResult signInResult =await _userService.PasswordSignIn(_mapper.Map<PasswordSignInUserDTO>(signInUserViewModel));

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
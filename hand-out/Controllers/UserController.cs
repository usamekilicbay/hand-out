using AutoMapper;
using BusinessLogicLayer;
using BusinessLogicLayer.Services.Abstract;
using EntityLayer.Concrete;
using hand_out.Models;
using hand_out.Models.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using static Sidekick.NET.Types;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace hand_out.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public UserController(DataAccessLayer.ApplicationDbContext applicationDbContext, IMapper mapper,
            UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _unitOfWork = new UnitOfWork(applicationDbContext, mapper, userManager, signInManager);
            _userService = _unitOfWork.UserService;
        }

        [Authorize()]
        [HttpGet]
        public IActionResult Details()
        {
            return View(_userService.GetUserDetails<DetailsUserViewModel>(HttpContext.User));
        }

        public IActionResult Edit()
        {
            return View(new ProfileEditViewModel
            {
                Name = "Usame Kilicbay",
                Mail = "usame.kilicbay@protonmail.com",
                Address = "Turkey",
                ProfilePicURL = "https://media-exp1.licdn.com/dms/image/C5603AQEoe9--htofaA/profile-displayphoto-shrink_800_800/0/1576480070508?e=1644451200&v=beta&t=UBn25UjZZOMD16JzYKJtWGukEhFohlRe59w462JZy18",
            });
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

            IdentityResult identityResult = _userService.SignUp(signUpUserViewModel, signUpUserViewModel.Password);

            if (!identityResult.Succeeded)
            {
                List<IdentityError> errors = identityResult.Errors.ToList();
                errors.ForEach(e => ModelState.AddModelError(e.Code, e.Code));
                return View();
            }

            return RedirectToAction("Details");
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SignInUserViewModel signInUserViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            SignInResult signInResult = _userService.PasswordSignIn(signInUserViewModel.Username,
                                                            signInUserViewModel.Password,
                                                            signInUserViewModel.RememberMe);

            if (!signInResult.Succeeded)
            {
                return View();
            }

            return RedirectToAction("Details");
        }

        public IActionResult LogOut()
        {
            return RedirectToAction("SignIn");
        }

        public IActionResult Authenticate()
        {
            return RedirectToAction("Details");
        }
    }
}

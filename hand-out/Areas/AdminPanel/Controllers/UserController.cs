using AutoMapper;
using BusinessLogicLayer;
using BusinessLogicLayer.Services.Abstract;
using hand_out.Areas.AdminPanel.Models.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace hand_out.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public UserController(DataAccessLayer.ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _unitOfWork = new UnitOfWork(applicationDbContext, mapper);
            _userService = _unitOfWork.UserService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_userService.GetAll<ListUserViewModel>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(CreateUserViewModel userCreateViewModel)
        {
            if (!ModelState.IsValid)
                return Redirect("Create");

            _userService.Insert(userCreateViewModel);

            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_userService.GetByID<UpdateUserViewModel>(id));
        }

        [HttpPost]
        public IActionResult Update(UpdateUserViewModel userUpdateViewModel)
        {
            if (!ModelState.IsValid)
                return Redirect("Edit");

            _userService.Update(userUpdateViewModel);

            return RedirectToAction("Index");
        }
    }
}

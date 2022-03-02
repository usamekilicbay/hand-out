using AutoMapper;
using BusinessLogicLayer;
using BusinessLogicLayer.Services.Abstract;
using DataLayer.Areas.Admin.User;
using hand_out.Areas.Admin.Models.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace hand_out.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("AdminPanel")]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IMapper mapper, IUserService userService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vararara = _userService.GetAll<ListUserDTO>();
            return View(_mapper.Map<List<ListUserViewModel>>(vararara));
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

            _userService.Insert(_mapper.Map<CreateUserDTO>(userCreateViewModel));

            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            return View(_mapper.Map<UpdateUserViewModel>(_userService.GetById<UpdateUserDTO>(id)));
        }

        [HttpPost]
        public IActionResult Update(UpdateUserViewModel userUpdateViewModel)
        {
            if (!ModelState.IsValid)
                return Redirect("Edit");

            _userService.Update(_mapper.Map<UpdateUserDTO>(userUpdateViewModel));

            return RedirectToAction("Index");
        }
    }
}
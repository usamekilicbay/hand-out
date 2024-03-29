﻿using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using DataLayer.Areas.Admin.Category;
using hand_out.Areas.Admin.Models.ViewModels.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using X.PagedList;

namespace hand_out.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            List<ListCategoryDTO> listCategoryDTOs = _categoryService.GetAll<ListCategoryDTO>();
            List<ListCategoryViewModel> listCategoryViewModels = _mapper.Map<List<ListCategoryViewModel>>(listCategoryDTOs);
            return View(listCategoryViewModels.ToPagedList(page, 8));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(CreateCategoryViewModel createCategoryViewModel)
        {
            _categoryService.Insert(_mapper.Map<CreateCategoryDTO>(createCategoryViewModel));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_mapper.Map<UpdateCategoryViewModel>(_categoryService.GetById<UpdateCategoryDTO>(id)));
        }

        [HttpPost]
        public IActionResult Update(UpdateCategoryViewModel updateCategoryViewModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Edit");

            _categoryService.Update(_mapper.Map<UpdateCategoryDTO>(updateCategoryViewModel), updateCategoryViewModel.Id);

            return RedirectToAction("Index");
        }
    }
}
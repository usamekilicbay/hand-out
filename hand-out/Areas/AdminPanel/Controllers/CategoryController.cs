using AutoMapper;
using BusinessLogicLayer;
using BusinessLogicLayer.Services.Abstract;
using EntityLayer.Concrete;
using hand_out.Areas.AdminPanel.Models.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace hand_out.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(DataAccessLayer.ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _unitOfWork = new UnitOfWork(applicationDbContext, mapper);
            _categoryService = _unitOfWork.CategoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_categoryService.GetAll<Category>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(CreateCategoryViewModel createCategoryViewModel)
        {
            _categoryService.Insert(createCategoryViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_categoryService.GetByID<UpdateCategoryViewModel>(id));
        }

        [HttpPost]
        public IActionResult Update(UpdateCategoryViewModel updateCategoryViewModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Edit");

            _categoryService.Update(updateCategoryViewModel);

            return RedirectToAction("Index");
        }
    }
}

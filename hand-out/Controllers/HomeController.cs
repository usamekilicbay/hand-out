using AutoMapper;
using BusinessLogicLayer;
using DataAccessLayer;
using hand_out.Models.ViewModels.Category;
using hand_out.Models.ViewModels.Product;
using hand_out.Models.ViewModels.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hand_out.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _unitOfWork = new UnitOfWork(applicationDbContext, mapper);
        }

        public IActionResult Index()
        {
            IndexViewModel indexViewModel = new IndexViewModel
            {
                ListProductViewModel = _unitOfWork.ProductService.GetAll<ListProductViewModel>(),
                ListCategoryViewModel = _unitOfWork.CategoryService.GetAll<ListCategoryViewModel>()
            };

            return View(indexViewModel);
        }
    }
}

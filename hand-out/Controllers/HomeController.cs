using BusinessLogicLayer;
using DataLayer.ViewModels.Category;
using DataLayer.ViewModels.Product;
using DataLayer.ViewModels.Shared;
using Microsoft.AspNetCore.Mvc;

namespace hand_out.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IndexViewModel indexViewModel = new(
                listProductViewModels: _unitOfWork.ProductService.GetAll<ListProductViewModel>(),
                listCategoryViewModels: _unitOfWork.CategoryService.GetAll<ListCategoryViewModel>());

            return View(indexViewModel);
        }
    }
}

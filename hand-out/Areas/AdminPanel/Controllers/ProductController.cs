using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services.Abstract;
using AutoMapper;
using BusinessLogicLayer;
using hand_out.Areas.AdminPanel.Models.ViewModels.Product;

namespace hand_out.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;

        public ProductController(DataAccessLayer.ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _unitOfWork = new UnitOfWork(applicationDbContext, mapper);
            _productService = _unitOfWork.ProductService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_productService.GetAll<ListProductViewModel>());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_productService.GetByID<UpdateProductViewModel>(id));
        }

        [HttpPost]
        public IActionResult Update(UpdateProductViewModel updateProductViewModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Edit");

            _productService.Update(updateProductViewModel);

            return RedirectToAction("Index");
        }
    }
}

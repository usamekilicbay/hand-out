using AutoMapper;
using BusinessLogicLayer;
using DataLayer.Category;
using DataLayer.Product;
using hand_out.Models.ViewModels.Category;
using hand_out.Models.ViewModels.Product;
using hand_out.Models.ViewModels.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace hand_out.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(int id = 0)
        {
            List<ListProductDTO> listProducts = id != 0
                ? _unitOfWork.ProductService.GetAllWithRelations<ListProductDTO>(p => p.CategoryId == id)
                : _unitOfWork.ProductService.GetAllWithRelations<ListProductDTO>();

            IndexViewModel indexViewModel = new(
                listProductViewModels: _mapper.Map<List<ListProductViewModel>>(listProducts),
                listCategoryViewModels: _mapper.Map<List<ListCategoryViewModel>>(_unitOfWork.CategoryService.GetAll<ListCategoryDTO>()));

            return View(indexViewModel);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
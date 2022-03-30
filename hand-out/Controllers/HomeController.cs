using AutoMapper;
using BusinessLogicLayer;
using DataLayer.Category;
using DataLayer.Product;
using hand_out.Models.ViewModels.Category;
using hand_out.Models.ViewModels.Product;
using hand_out.Models.ViewModels.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult Index(int categoryId = 0)
        {
            List<ListProductDTO> listProductDTOs = categoryId != 0
                ? _unitOfWork.ProductService.GetAllWithRelations<ListProductDTO>(p => p.CategoryId == categoryId)
                : _unitOfWork.ProductService.GetAllWithRelations<ListProductDTO>();

            IndexViewModel indexViewModel = new(
                listProductViewModels: _mapper.Map<List<ListProductViewModel>>(listProductDTOs).OrderBy(x => new Random().Next()).ToList(),
                listCategoryViewModels: _mapper.Map<List<ListCategoryViewModel>>(_unitOfWork.CategoryService.GetAll<ListCategoryDTO>()));

            return View(indexViewModel);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IEnumerable<ListProductViewModel> GetProducts(string nameIncludes)
        {
            if (string.IsNullOrEmpty(nameIncludes))
                return _mapper.Map<IEnumerable<ListProductViewModel>>(_unitOfWork.ProductService.GetAllWithRelations<ListProductDTO>());

            IEnumerable<ListProductDTO> listProductDTOs = _unitOfWork.ProductService.
                GetAllWithRelations<ListProductDTO>(x => x.Name.Contains(nameIncludes)).
                OrderBy(x => new Random().Next()).ToList();

            return _mapper.Map<IEnumerable<ListProductViewModel>>(listProductDTOs);
        }
    }
}
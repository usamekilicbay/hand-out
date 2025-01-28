using AutoMapper;
using BusinessLogicLayer;
using DataLayer.Category;
using DataLayer.Product;
using hand_out.Models.ViewModels.Category;
using hand_out.Models.ViewModels.Product;
using hand_out.Models.ViewModels.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using static Sidekick.NET.Types;

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

        public IActionResult Index()
        {
            IEnumerable<ListProductDTO> listProductDTOs = _unitOfWork.ProductService.
                GetAllWithRelations<ListProductDTO>(p => p.Status == ProductStatus.ACTIVE);

            IndexViewModel indexViewModel = new(
                listProductViewModels: _mapper.Map<IEnumerable<ListProductViewModel>>(listProductDTOs).OrderBy(p => new Random().Next()).ToList(),
                listCategoryViewModels: _mapper.Map<List<ListCategoryViewModel>>(_unitOfWork.CategoryService.GetAll<ListCategoryDTO>()));

            return View(indexViewModel);
        }

        public IEnumerable<ListProductViewModel> GetProductsBySearchedWord(string nameIncludes)
        {
            if (string.IsNullOrEmpty(nameIncludes))
                return _mapper.Map<IEnumerable<ListProductViewModel>>(_unitOfWork.ProductService.
                    GetAllWithRelations<ListProductDTO>(p => p.Status == ProductStatus.ACTIVE));

            IEnumerable<ListProductDTO> listProductDTOs = _unitOfWork.ProductService.
                GetAllWithRelations<ListProductDTO>(p => p.Name.Contains(nameIncludes) && p.Status == ProductStatus.ACTIVE).
                OrderBy(x => new Random().Next()).ToList();

            return _mapper.Map<IEnumerable<ListProductViewModel>>(listProductDTOs);
        }

        public IEnumerable<ListProductViewModel> GetProductsByCategory(int categoryId)
        {
            IEnumerable<ListProductDTO> listProductDTOs = _unitOfWork.ProductService.
                    GetAllWithRelations<ListProductDTO>(p => p.CategoryId == categoryId && p.Status == ProductStatus.ACTIVE);

            IEnumerable<ListProductViewModel> listProductViewModels = _mapper.Map<IEnumerable<ListProductViewModel>>(listProductDTOs)
                .OrderBy(x => new Random().Next()).ToList();

            return listProductViewModels;
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
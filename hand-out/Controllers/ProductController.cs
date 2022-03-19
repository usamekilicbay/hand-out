using AutoMapper;
using BusinessLogicLayer;
using BusinessLogicLayer.Services.Abstract;
using DataLayer.Category;
using DataLayer.Product;
using EntityLayer.Concrete;
using hand_out.Models.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Sidekick.NET.Types;

namespace hand_out.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IProductService productService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _productService = productService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Insert([Bind(Prefix = "CreateProductViewModel")] CreateProductViewModel createProductViewModel)
        {
            if (!ModelState.IsValid)
                return null;

            _productService.Insert(_mapper.Map<CreateProductDTO>(createProductViewModel));

            return RedirectToAction("Details", "User");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            DetailsProductDTO detailsProductDTO = _productService.GetAllWithRelations<DetailsProductDTO>(p => p.Id == id).FirstOrDefault();

            ViewBag.IsYourWare = _unitOfWork.UserService.GetCurrentUserId() == detailsProductDTO.GrantorId;

            return View(_mapper.Map(detailsProductDTO, new DetailsProductViewModel(detailsProductDTO.PhotoURL)));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            UpdateProductDTO updateProductDTO = _productService.GetAllWithRelations<UpdateProductDTO>(p => p.Id == id).FirstOrDefault();
            ViewBag.Categories = new SelectList(_unitOfWork.CategoryService.GetAll<DropdownCategoryDTO>(), "Id", "Name");

            return View(_mapper.Map(updateProductDTO, new UpdateProductViewModel(updateProductDTO.PhotoURL)));
        }

        [HttpPost]
        public IActionResult Update(UpdateProductViewModel updateProductViewModel)
        {
            _unitOfWork.ProductService.Update(_mapper.Map(updateProductViewModel, new UpdateProductDTO()));

            return RedirectToAction("Details");
        }
    }
}
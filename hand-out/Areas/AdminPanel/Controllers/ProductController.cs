using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services.Abstract;
using hand_out.Areas.Admin.Models.ViewModels.Product;
using DataLayer.Areas.Admin.Product;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using X.PagedList;

namespace hand_out.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            List<ListProductDTO> listProductDTOs = _productService.GetAllWithRelations<ListProductDTO>();
            List<ListProductViewModel> listProductViewModels = _mapper.Map<List<ListProductViewModel>>(listProductDTOs);

            return View(listProductViewModels.ToPagedList(page, 7));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_mapper.Map<ListProductViewModel>(_productService.GetById<UpdateProductDTO>(id)));
        }

        [HttpPost]
        public IActionResult Update(UpdateProductViewModel updateProductViewModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Edit");

            _productService.Update(_mapper.Map<UpdateProductDTO>(updateProductViewModel));

            return RedirectToAction("Index");
        }
    }
}
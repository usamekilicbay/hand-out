using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using DataLayer.Product;
using hand_out.Models.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace hand_out.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([Bind(Prefix = "CreateProductViewModel")] CreateProductViewModel createProductViewModel)
        {
            if (!ModelState.IsValid)
                return null;

            await _productService.InsertAsync(_mapper.Map<CreateProductDTO>(createProductViewModel));

            return RedirectToAction("Details", "User");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            //DetailsProductDTO detailsProductDTO = _productService.GetById<DetailsProductDTO>(new Random().Next(2, 6));
            DetailsProductDTO detailsProductDTO = _productService.GetById<DetailsProductDTO>(id);
            //DetailsProductDTO detailsProductDTO = _productService.GetById<DetailsProductDTO>(6);
            return View(_mapper.Map(detailsProductDTO, new DetailsProductViewModel(detailsProductDTO.PhotoURL)));
        }
    }
}
using AutoMapper;
using BusinessLogicLayer;
using BusinessLogicLayer.Services.Abstract;
using DataLayer.Category;
using DataLayer.Product;
using hand_out.Models.ViewModels.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

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
            ViewBag.Categories = new SelectList(_unitOfWork.CategoryService.GetAll<DropdownCategoryDTO>(), "Id", "Name");

            UpdateProductDTO updateProductDTO = _productService.GetAllWithRelations<UpdateProductDTO>(p => p.Id == id).FirstOrDefault();
            updateProductDTO.SetPhotoURLs();

            UpdateProductViewModel updateProductViewModel = _mapper.Map<UpdateProductViewModel>(updateProductDTO);

            return View(updateProductViewModel);
        }

        [HttpPost]
        public IActionResult Update(UpdateProductViewModel updateProductViewModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Edit", new { id = updateProductViewModel.Id });

            updateProductViewModel.PhotoURLs = new();

            FormCollection requestForm = (FormCollection)Request.Form;

            foreach (string key in requestForm.Keys)
            {
                if (!key.Contains("img-name"))
                    continue;

                string val = requestForm[key];

                if (!string.IsNullOrEmpty(val))
                    updateProductViewModel.PhotoURLs.Add(val);
            }

            if (updateProductViewModel.Photos == null && updateProductViewModel.PhotoURLs.Count <= 0)
                return RedirectToAction("Edit", new { id = updateProductViewModel.Id });


            UpdateProductDTO updateProductDTO = _mapper.Map(updateProductViewModel, new UpdateProductDTO());

            _unitOfWork.ProductService.Update(updateProductDTO);

            return RedirectToAction("Details", new { id = updateProductViewModel.Id });
        }
    }
}
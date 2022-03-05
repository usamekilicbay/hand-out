using AutoMapper;
using BusinessLogicLayer;
using BusinessLogicLayer.Services.Abstract;
using DataLayer.Product;
using hand_out.Models.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

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
            DetailsProductDTO detailsProductDTO = _productService.GetAllWithRelations<DetailsProductDTO>(p => p.Id == id).FirstOrDefault();

            ViewBag.IsYourWare = _unitOfWork.UserService.GetCurrentUserId() == detailsProductDTO.GrantorId;

            return View(_mapper.Map(detailsProductDTO, new DetailsProductViewModel(detailsProductDTO.PhotoURL)));
        }
    }
}
using BusinessLogicLayer.Services.Abstract;
using DataLayer.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace hand_out.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert([Bind(Prefix = "ProductCreateViewModel")] DataLayer.ViewModels.Product.CreateProductViewModel createProductViewModel)
        {
            await _productService.InsertAsync(createProductViewModel);
            return Redirect("");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            //Product product = _productService.GetByID<Product>(id);
            DetailsProductViewModel detailsProductViewModel = new DetailsProductViewModel("https://www.thespruce.com/thmb/LKOvcb4_oAZ3EBAimkOaejLD5xs=/1444x1304/filters:no_upscale():max_bytes(150000):strip_icc()/CubiCubiStudyComputerDesk-3af29714166b4ac0b6f2d4a4b80fe763.jpg|" +
                                                                                           "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRr9jTSCSnAActRKlbYhvsXZbPv-rcoEZoaRQ&usqp=CAU|" +
                                                                                           "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSyasvJjPeL2ke-ywj0v-u9TPFnhxFANBxmOg&usqp=CAU")
            {
                Name = "Study Desk",
                Details = "L-Shaped Corner Desk: This computer desk flaunts modern design with round corner fits well into any type of corner in your room, the L-shaped design create ideal workspace, saving the space of your home office maximum and providing plenty of surface space for you.",
                Address = "Dublin",
                CategoryName = "Furniture",
                CategoryIcon = "fa-couch",
                GrantorId = "ul522kfjcitdfjoo44k",
                GrantorName = "Usame K.",
                GrantorPhotoURL = "https://media-exp1.licdn.com/dms/image/C5603AQEoe9--htofaA/profile-displayphoto-shrink_800_800/0/1576480070508?e=1648080000&v=beta&t=Zjhw1W_yLL_k0Q20eVQNkxjrsX1dbveVVWyGjc_lFgs",
                DatePublished = System.DateTime.Now,
            };

            return View(detailsProductViewModel);
        }
    }
}

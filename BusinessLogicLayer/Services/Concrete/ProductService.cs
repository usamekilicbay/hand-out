using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using DataAccessLayer;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Concrete;
using DataLayer.Product;
using EntityLayer.Concrete;
using Sidekick.NET;
using Constant = Sidekick.NET.Constant;

namespace BusinessLogicLayer.Services.Concrete
{
    public class ProductService : Service<Product, int>, IProductService
    {
        public IProductRepository ProductRepository { get; set; }

        public ProductService(ApplicationDbContext applicationDbContext,
            IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            ProductRepository = new ProductRepository(applicationDbContext);
            Repository = ProductRepository;
        }

        public void Insert(CreateProductDTO createProductDTO)
        {
            Product product = mapper.Map<Product>(createProductDTO);
            product.PhotoURL = FileOperations.SavePhotos(createProductDTO.Photos, Constant.Path.PRODUCT_IMAGES);
            product.GrantorId = UnitOfWork.UserService.GetCurrentUserId();

            ProductRepository.Insert(product);
        }

        public void Update(UpdateProductDTO updateProductDTO)
        {
            Product product = GetById<Product>(updateProductDTO.Id);
            string oldPhotoURL = product.PhotoURL;

            Product updatedProduct = mapper.Map(updateProductDTO, product);

            updatedProduct.PhotoURL = FileOperations.UpdatePhotos(updateProductDTO.Photos, updateProductDTO.PhotoURLs, oldPhotoURL, Constant.Path.PRODUCT_IMAGES);

            ProductRepository.Update(product);
        }
    }
}
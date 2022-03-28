using DataAccessLayer.Repositories.Abstract;
using DataLayer.Product;
using EntityLayer.Concrete;

namespace BusinessLogicLayer.Services.Abstract
{
    public interface IProductService : IService<Product, int>
    {
        IProductRepository ProductRepository { get; set; }

        void Insert(CreateProductDTO createProductDTO);
        void Update(UpdateProductDTO updateProductDTO);
    }
}
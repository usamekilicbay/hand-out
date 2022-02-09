using DataAccessLayer.Repositories.Abstract;
using DataLayer.Product;
using EntityLayer.Concrete;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Abstract
{
    public interface IProductService : IService<Product>
    {
        public IProductRepository ProductRepository { get; set; }

        public Task InsertAsync(CreateProductDTO productModel);
    }
}
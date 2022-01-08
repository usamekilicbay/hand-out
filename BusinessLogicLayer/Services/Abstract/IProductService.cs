using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;

namespace BusinessLogicLayer.Services.Abstract
{
    public interface IProductService : IService<Product>
    {
        public IProductRepository ProductRepository { get; set; }
    }
}

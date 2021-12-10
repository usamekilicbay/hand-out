using DataAccessLayer.Repositories.Abstract;
using System;

namespace DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        int Complete();
    }
}

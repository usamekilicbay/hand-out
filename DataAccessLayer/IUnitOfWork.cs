using DataAccessLayer.Repositories.Abstract;
using System;

namespace DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository UserRepository { get; }
        public IProductRepository ProductRepository { get; }
        public ICategoryRepository CategoryRepository { get; }

        int SaveChanges();
    }
}

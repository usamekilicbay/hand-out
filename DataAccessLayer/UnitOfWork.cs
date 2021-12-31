using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Concrete;

namespace DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public ICategoryRepository CategoryRepository { get; private set; }

        public IProductRepository ProductRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            CategoryRepository = new CategoryRepository(_dbContext);
            ProductRepository = new ProductRepository(_dbContext);
            UserRepository = new UserRepository(_dbContext);
        }

        public int SaveChanges() => 
            _dbContext.SaveChanges();


        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}

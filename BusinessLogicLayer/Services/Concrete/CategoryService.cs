using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using DataAccessLayer;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Concrete;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services.Concrete
{
    public class CategoryService : Service<Category, int>, ICategoryService
    {
        public ICategoryRepository CategoryRepository { get; set; }

        public CategoryService(ApplicationDbContext applicationDbContext,
            IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            CategoryRepository = new CategoryRepository(applicationDbContext);
            Repository = CategoryRepository;
        }

        public List<string> GetCategoryNames()
        {
            List<string> categoryNames = new();
            Repository.GetAll().
                ForEach(category => categoryNames.Add(category.Name));

            return categoryNames;
        }
    }
}
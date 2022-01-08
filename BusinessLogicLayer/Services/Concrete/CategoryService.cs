using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using DataAccessLayer;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Concrete;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services.Concrete
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public ICategoryRepository CategoryRepository { get; set; }

        public CategoryService(ApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper)
        {
            CategoryRepository = new CategoryRepository(applicationDbContext);
            Repository = CategoryRepository;
        }

        public List<string> GetCategoryNames()
        {
            List<Category> categories = Repository.GetAll();
            List<string> categoryNames = new();

            foreach (Category category in categories)
                categoryNames.Add(category.Name);

            return categoryNames;
        }
    }
}

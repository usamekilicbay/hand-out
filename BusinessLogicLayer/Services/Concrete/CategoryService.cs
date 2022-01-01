using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using DataAccessLayer;
using DataAccessLayer.Repositories.Concrete;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services.Concrete
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(ApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper)
        {
            Repository = new CategoryRepository(applicationDbContext);
        }

        public List<string> GetCategoryNames()
        {
            List<Category> categories = Repository.GetAll();
            List<string> categoryNames = new List<string>();

            foreach (Category category in categories)
                categoryNames.Add(category.Name);

            return categoryNames;
        }
    }
}

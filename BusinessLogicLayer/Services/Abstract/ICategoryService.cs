using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services.Abstract
{
    public interface ICategoryService : IService<Category, int>
    {
        public ICategoryRepository CategoryRepository { get; set; }
        public List<string> GetCategoryNames();
    }
}
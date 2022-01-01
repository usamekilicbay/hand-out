using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services.Abstract
{
    public interface ICategoryService : IService<Category>
    {
        public List<string> GetCategoryNames();
    }
}

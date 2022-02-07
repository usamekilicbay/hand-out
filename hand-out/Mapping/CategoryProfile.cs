using AutoMapper;
using EntityLayer.Concrete;
using DataLayer.ViewModels.Category;

namespace hand_out.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, ListCategoryViewModel>()
                .ReverseMap();
        }
    }
}

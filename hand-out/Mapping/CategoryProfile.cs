using AutoMapper;
using EntityLayer.Concrete;
using hand_out.Models.ViewModels.Category;

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

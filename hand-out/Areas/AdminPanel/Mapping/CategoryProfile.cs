using AutoMapper;
using EntityLayer.Concrete;
using hand_out.Areas.AdminPanel.Models.ViewModels.Category;

namespace hand_out.Areas.AdminPanel.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, ListCategoryViewModel>()
               .ReverseMap();

            CreateMap<Category, CreateCategoryViewModel>()
                .ReverseMap();

            CreateMap<Category, UpdateCategoryViewModel>()
                .ReverseMap();
        }
    }
}

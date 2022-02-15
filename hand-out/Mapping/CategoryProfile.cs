using AutoMapper;
using DataLayer.Category;
using EntityLayer.Concrete;
using hand_out.Models.ViewModels.Category;

namespace hand_out.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            #region Entity <---> DTO
            CreateMap<Category, ListCategoryDTO>().ReverseMap();

            CreateMap<Category, DropdownCategoryDTO>().ReverseMap();
            #endregion

            #region View Model <---> DTO
            CreateMap<ListCategoryViewModel, ListCategoryDTO>().ReverseMap();

            CreateMap<DropdownCategoryViewModel, DropdownCategoryDTO>().ReverseMap();
            #endregion
        }
    }
}
using AutoMapper;
using DataLayer.Areas.Admin.Category;
using EntityLayer.Concrete;
using hand_out.Areas.Admin.Models.ViewModels.Category;

namespace hand_out.Areas.Admin.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            #region Entity <---> DTO
            CreateMap<Category, ListCategoryDTO>().ReverseMap();

            CreateMap<Category, CreateCategoryDTO>().ReverseMap();

            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            #endregion

            #region View Model <---> DTO
            CreateMap<ListCategoryViewModel, ListCategoryDTO>().ReverseMap();

            CreateMap<CreateCategoryViewModel, CreateCategoryDTO>().ReverseMap();

            CreateMap<UpdateCategoryViewModel, UpdateCategoryDTO>().ReverseMap();
            #endregion
        }
    }
}
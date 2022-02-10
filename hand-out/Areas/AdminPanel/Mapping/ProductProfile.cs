using AutoMapper;
using DataLayer.Areas.Admin.Product;
using EntityLayer.Concrete;
using hand_out.Areas.Admin.Models.ViewModels.Product;

namespace hand_out.Areas.Admin.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            #region Entity <---> DTO
            CreateMap<Product, ListProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();

            #endregion

            #region View Model <---> DTO
            CreateMap<ListProductViewModel, ListProductDTO>().ReverseMap();
            CreateMap<UpdateProductViewModel, UpdateProductDTO>().ReverseMap();
            #endregion
        }
    }
}
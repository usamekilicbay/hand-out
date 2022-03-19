using AutoMapper;
using DataLayer.Product;
using EntityLayer.Concrete;
using hand_out.Models.ViewModels.Product;
using System.Linq;

namespace hand_out.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            #region Entity <---> DTO
            CreateMap<Product, ListProductDTO>().ReverseMap();

            CreateMap<Product, CreateProductDTO>().ReverseMap();

            CreateMap<Product, DetailsProductDTO>().ForMember(dto =>
            dto.CategoryIcon, opt =>
            opt.MapFrom(entity => entity.Category.FontAwesomeIconName))
                .ReverseMap();

            CreateMap<Product, UpdateProductDTO>().ReverseMap();

            CreateMap<Product, MessageProductDTO>().ReverseMap();
            #endregion

            #region View Model <---> DTO
            CreateMap<ListProductViewModel, ListProductDTO>().ReverseMap();

            CreateMap<CreateProductViewModel, CreateProductDTO>().ReverseMap();

            CreateMap<DetailsProductViewModel, DetailsProductDTO>().ReverseMap();

            CreateMap<UpdateProductDTO, UpdateProductViewModel>().ReverseMap();

            CreateMap<MessageProductViewModel, MessageProductDTO>().ReverseMap();
            #endregion
        }
    }
}
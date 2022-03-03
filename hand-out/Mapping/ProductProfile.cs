using AutoMapper;
using DataLayer.Product;
using EntityLayer.Concrete;
using hand_out.Models.ViewModels.Product;

namespace hand_out.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            #region Entity <---> DTO
            CreateMap<Product, ListProductDTO>().ReverseMap();

            CreateMap<Product, CreateProductDTO>().ReverseMap();

            CreateMap<Product, DetailsProductDTO>().ForMember(entity =>
            entity.CategoryIcon, 
            opt => opt.MapFrom(dto => dto.Category.FontAwesomeIconName))
                .ReverseMap();

            CreateMap<Product, MessageProductDTO>().ReverseMap();
            #endregion

            #region View Model <---> DTO
            CreateMap<ListProductViewModel, ListProductDTO>().ReverseMap();

            CreateMap<CreateProductViewModel, CreateProductDTO>().ReverseMap();

            CreateMap<DetailsProductViewModel, DetailsProductDTO>().ReverseMap();

            CreateMap<MessageProductViewModel, MessageProductDTO>().ReverseMap();
            #endregion
        }
    }
}
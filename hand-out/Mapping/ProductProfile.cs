using AutoMapper;
using EntityLayer.Concrete;
using hand_out.Models.ViewModels.Product;

namespace hand_out.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ListProductViewModel>()
                .ReverseMap();

            CreateMap<Product, CreateProductViewModel>()
                .ReverseMap();
        }
    }
}

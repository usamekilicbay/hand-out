using AutoMapper;
using EntityLayer.Concrete;
using DataLayer.ViewModels.Product;

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

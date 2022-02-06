using AutoMapper;
using EntityLayer.Concrete;
using hand_out.Areas.Admin.Models.ViewModels.Product;

namespace hand_out.Areas.Admin.Mapping
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ListProductViewModel>()
                .ReverseMap();

            CreateMap<Product, UpdateProductViewModel>()
                .ReverseMap();
        }
    }
}

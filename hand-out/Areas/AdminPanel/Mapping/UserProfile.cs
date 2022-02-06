using AutoMapper;
using EntityLayer.Concrete;
using hand_out.Areas.Admin.Models.ViewModels.User;

namespace hand_out.Areas.Admin.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, ListUserViewModel>()
                .ReverseMap();

            CreateMap<User, CreateUserViewModel>()
                .ReverseMap();

            CreateMap<User, UpdateUserViewModel>()
            .ReverseMap();
        }
    }
}
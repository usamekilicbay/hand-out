using AutoMapper;
using EntityLayer.Concrete;
using hand_out.Areas.AdminPanel.Models.ViewModels.User;

namespace hand_out.Areas.AdminPanel.Mapping
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

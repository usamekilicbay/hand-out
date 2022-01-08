using AutoMapper;
using EntityLayer.Concrete;
using hand_out.Models.ViewModels.User;

namespace hand_out.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, DetailsUserViewModel>()
                .ReverseMap();

            CreateMap<User, SignUpUserViewModel>()
                .ReverseMap();

            CreateMap<User, SignInUserViewModel>()
                .ReverseMap();
        }
    }
}

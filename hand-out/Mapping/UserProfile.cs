using AutoMapper;
using DataLayer.General.User;
using DataLayer.User;
using EntityLayer.Concrete;
using hand_out.Models.ViewModels.User;

namespace hand_out.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            #region Entity <---> DTO
            CreateMap<User, DetailsUserDTO>().ReverseMap();
            
            CreateMap<User, UpdateUserDTO>().ReverseMap();

            CreateMap<User, SignUpUserDTO>().ReverseMap();

            CreateMap<User, PasswordSignInUserDTO>().ReverseMap();
            #endregion

            #region View Model <---> DTO
            CreateMap<DetailsUserViewModel, DetailsUserDTO>().ReverseMap();

            CreateMap<SignUpUserViewModel, SignUpUserDTO>().ReverseMap();

            CreateMap<PasswordSignInUserViewModel, PasswordSignInUserDTO>().ReverseMap();
            #endregion
        }
    }
}
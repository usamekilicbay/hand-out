using AutoMapper;
using DataLayer.Areas.Admin.User;
using EntityLayer.Concrete;
using hand_out.Areas.Admin.Models.ViewModels.User;

namespace hand_out.Areas.Admin.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            #region Entity <---> DTO
            CreateMap<User, ListUserDTO>().ReverseMap();

            CreateMap<User, CreateUserDTO>().ReverseMap();

            CreateMap<User, UpdateUserDTO>().ReverseMap();
            #endregion

            #region View Model <---> DTO
            CreateMap<ListUserViewModel, ListUserDTO>().ReverseMap();

            CreateMap<CreateUserViewModel, CreateUserDTO>().ReverseMap();

            CreateMap<UpdateUserViewModel, UpdateUserDTO>().ReverseMap();
            #endregion
        }
    }
}
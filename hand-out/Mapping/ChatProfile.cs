using AutoMapper;
using DataLayer.General.Chat;
using EntityLayer.Concrete;
using hand_out.Models.ViewModels.Chat;

namespace hand_out.Mapping
{
    public class ChatProfile : Profile
    {
        public ChatProfile()
        {
            #region Entity <---> DTO
            CreateMap<Chat, ChatDTO>().ReverseMap();
            CreateMap<Chat, CreateChatDTO>().ReverseMap();
            #endregion

            #region ViewModel <---> DTO
            CreateMap<ChatViewModel, ChatDTO>().ReverseMap();
            #endregion
        }
    }
}
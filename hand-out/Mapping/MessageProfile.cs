using AutoMapper;
using DataLayer.General.Message;
using EntityLayer.Concrete;
using hand_out.Models.ViewModels.Message;

namespace hand_out.Mapping
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            #region Entity <---> DTO
            CreateMap<Message, CreateMessageDTO>().ReverseMap();
            CreateMap<Message, MessageDTO>().ReverseMap();
            #endregion

            #region View Model <---> DTO
            CreateMap<MessageViewModel, MessageDTO>().ReverseMap();
            #endregion
        }
    }
}
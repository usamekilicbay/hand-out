using AutoMapper;
using DataLayer.General.Message;
using EntityLayer.Concrete;

namespace hand_out.Mapping
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            #region Entity <---> DTO
            CreateMap<Message, CreateMessageDTO>().ReverseMap();
            #endregion
        }
    }
}
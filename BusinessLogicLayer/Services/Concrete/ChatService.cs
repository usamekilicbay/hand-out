using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;

namespace BusinessLogicLayer.Services.Concrete
{
    public class ChatService : Service<Chat>, IChatService
    {
        public IChatRepository ChatRepository { get; set; }

        public ChatService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }
    }
}
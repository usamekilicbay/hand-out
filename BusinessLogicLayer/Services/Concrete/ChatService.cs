using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using DataAccessLayer;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Concrete;
using EntityLayer.Concrete;

namespace BusinessLogicLayer.Services.Concrete
{
    public class ChatService : Service<Chat>, IChatService
    {
        public IChatRepository ChatRepository { get; set; }

        public ChatService(ApplicationDbContext applicationDbContext, IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            ChatRepository = new ChatRepository(applicationDbContext);
            Repository = ChatRepository;
        }
    }
}
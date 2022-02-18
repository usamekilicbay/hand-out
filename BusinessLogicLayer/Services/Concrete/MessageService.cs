using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using DataAccessLayer;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Concrete;
using EntityLayer.Concrete;

namespace BusinessLogicLayer.Services.Concrete
{
    class MessageService : Service<Message>, IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(ApplicationDbContext applicationDbContext,IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _messageRepository = new MessageRepository(applicationDbContext);
            Repository = _messageRepository;
        }
    }
}
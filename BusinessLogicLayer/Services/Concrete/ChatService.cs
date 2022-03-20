using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using DataAccessLayer;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Concrete;
using DataLayer.General.Chat;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Services.Concrete
{
    public class ChatService : Service<Chat, string>, IChatService
    {
        public IChatRepository ChatRepository { get; set; }

        public ChatService(ApplicationDbContext applicationDbContext, IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            ChatRepository = new ChatRepository(applicationDbContext);
            Repository = ChatRepository;
        }

        public List<ChatDTO> GetAllWithRelations(Expression<Func<Chat, bool>> filter)
        {
            List<Chat> entities = ChatRepository.GetAllWithRelations(filter);
            List<ChatDTO> DTOs = mapper.Map<List<ChatDTO>>(entities);

            string currentUserId = UnitOfWork.UserService.GetCurrentUserId();

            for (int i = 0; i < DTOs.Count; i++)
            {
                Chat currentEntity = entities[i];
                ChatDTO currentDTO = DTOs[i];

                if (currentUserId == currentEntity.GrantorParticipantId)
                {
                    currentDTO.ReceiverParticipantId = currentEntity.NeedyParticipantId;
                    currentDTO.ReceiverParticipantUserName = currentEntity.NeedyParticipant.UserName;
                    currentDTO.ReceiverParticipantPhotoURL = currentEntity.NeedyParticipant.ProfilePhotoURL;
                }
                else
                {
                    currentDTO.ReceiverParticipantId = currentEntity.GrantorParticipantId;
                    currentDTO.ReceiverParticipantUserName = currentEntity.GrantorParticipant.UserName;
                    currentDTO.ReceiverParticipantPhotoURL = currentEntity.GrantorParticipant.ProfilePhotoURL;
                }
            }

            return DTOs;
        }

        public ChatDTO Insert(CreateChatDTO createChatDTO)
        {
            Chat chat = mapper.Map<Chat>(createChatDTO);
            chat.NeedyParticipantId = UnitOfWork.UserService.GetCurrentUserId();

            return mapper.Map<ChatDTO>(ChatRepository.Insert(chat));
        }
    }
}
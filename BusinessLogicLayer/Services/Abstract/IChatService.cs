using DataAccessLayer.Repositories.Abstract;
using DataLayer.General.Chat;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Services.Abstract
{
    public interface IChatService : IService<Chat, string>
    {
        IChatRepository ChatRepository { get; set; }

        ChatDTO Insert(CreateChatDTO createChatDTO);
        List<ChatDTO> GetAllWithRelations(Expression<Func<Chat, bool>> filter);
    }
}
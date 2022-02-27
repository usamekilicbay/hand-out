using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.Concrete
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override List<Message> GetAllWithRelations()
            => dbSet
            .Include(m => m.Chat)
            .Include(m => m.Sender)
            .Include(m => m.Receiver)
            .ToList();

        public override List<Message> GetAllWithRelations(Expression<Func<Message, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.Concrete
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override List<Message> GetAllWithRelations()
        {
            throw new System.NotImplementedException();
        }

        public override List<Message> GetAllWithRelations(Expression<Func<Message, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public override Message GetByIdWithRelations(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
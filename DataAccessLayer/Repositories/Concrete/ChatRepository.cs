using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.Concrete
{
    public class ChatRepository : Repository<Chat>, IChatRepository
    {
        public ChatRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public override List<Chat> GetAllWithRelations()
        {
            throw new NotImplementedException();
        }

        public override List<Chat> GetAllWithRelations(Expression<Func<Chat, bool>> filter)
            => dbSet
            .Where(filter)
            .Include(c => c.Product)
            .Include(c => c.GrantorParticipant)
            .Include(c => c.NeedyParticipant)
            .ToList();
    }
}

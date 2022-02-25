using System;
using System.Collections.Generic;

namespace EntityLayer.Concrete
{
    public class Chat
    {
        public string Id { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string GrantorParticipantId { get; set; }
        public virtual User GrantorParticipant { get; set; }
        public string NeedyParticipantId { get; set; }
        public virtual User NeedyParticipant { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
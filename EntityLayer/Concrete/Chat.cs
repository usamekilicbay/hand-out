using System;
using System.Collections.Generic;

namespace EntityLayer.Concrete
{
    public class Chat
    {
        public string Id { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string GrantorParticipantId { get; set; }
        public User GrantorParticipant { get; set; }
        public string NeedyParticipantId { get; set; }
        public User NeedyParticipant { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
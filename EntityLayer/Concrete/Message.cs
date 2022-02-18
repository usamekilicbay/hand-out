using System;

namespace EntityLayer.Concrete
{
    public class Message
    {
        public string Id { get; set; }
        public string Context { get; set; }
        public DateTime DateSent { get; set; }

        public string SenderId { get; set; }
        public User Sender { get; set; }
        public string ReceiverId { get; set; }
        public User Receiver { get; set; }
    }
}
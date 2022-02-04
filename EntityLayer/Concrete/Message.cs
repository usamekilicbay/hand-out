using System;

namespace EntityLayer.Concrete
{
    public class Message
    {
        public string Id { get; set; }
        public string Context { get; set; }
        public DateTime DateSent { get; set; }
    }
}

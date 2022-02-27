using System;

namespace DataLayer.General.Message
{
    public class MessageDTO
    {
        public string Context { get; set; }
        public string SenderId;
        public DateTime DateSent { get; set; }
    }
}
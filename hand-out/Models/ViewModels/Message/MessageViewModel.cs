using System;

namespace hand_out.Models.ViewModels.Message
{
    public class MessageViewModel
    {
        public string Context { get; set; }
        public string SenderId { get; set; }
        public DateTime DateSent { get; set; }
        public bool IsYourMessage { get; set; }
    }
}
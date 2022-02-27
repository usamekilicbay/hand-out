using hand_out.Models.ViewModels.Message;
using System.Collections.Generic;

namespace hand_out.Models.ViewModels.Chat
{
    public class ChatViewModel
    {
        public string Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPhotoURL { get; set; }
        public string ReceiverParticipantId { get; set; }
        public string ReceiverParticipantUserName { get; set; }
        public string ReceiverParticipantPhotoURL { get; set; }
        public List<MessageViewModel> Messages { get; set; }
    }
}
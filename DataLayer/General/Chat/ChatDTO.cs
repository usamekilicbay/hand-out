using DataLayer.General.Message;
using System.Collections.Generic;

namespace DataLayer.General.Chat
{
    public class ChatDTO
    {
        public string Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPhotoURL { get; set; }
        public string ReceiverParticipantId { get; set; }
        public string ReceiverParticipantUserName { get; set; }
        public string ReceiverParticipantPhotoURL { get; set; }
        public List<MessageDTO> Messages { get; set; }
    }
}
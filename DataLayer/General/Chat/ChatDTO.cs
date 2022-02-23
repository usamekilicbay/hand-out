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
        public string GrantorParticipantId { get; set; }
        public string GrantorParticipantUserName { get; set; }
        public string GrantorParticipantPhotoURL { get; set; }
        public List<MessageDTO> Messages { get; set; }
    }
}
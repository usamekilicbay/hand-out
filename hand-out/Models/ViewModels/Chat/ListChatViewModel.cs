namespace hand_out.Models.ViewModels.Chat
{
    public class ListChatViewModel
    {
        public string Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPhotoURL { get; set; }
        public string SenderParticipantId { get; set; }
        public string ReceiverParticipantId { get; set; }
        public string ReceiverParticipantUserName { get; set; }
        public string ReceiverParticipantPhotoURL { get; set; }
        public string LastMessage { get; set; }
    }
}

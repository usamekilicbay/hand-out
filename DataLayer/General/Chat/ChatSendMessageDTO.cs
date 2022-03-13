namespace DataLayer.General.Chat
{
    public class ChatSendMessageDTO
    {
        public string Id { get; set; }
        public int ProductId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
    }
}

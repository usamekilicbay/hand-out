namespace DataLayer.General.Message
{
    public class CreateMessageDTO
    {
        public string ChatId { get; set; }
        public int ProductId { get; set; }
        public string ReceiverId { get; set; }
        public string Context { get; set; }
    }
}
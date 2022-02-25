namespace DataLayer.General.Chat
{
    public class CreateChatDTO
    {
        public string Id { get; set; }
        public int ProductId { get; set; }
        public string GrantorParticipantId { get; set; }
    }
}
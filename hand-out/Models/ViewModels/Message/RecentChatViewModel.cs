namespace hand_out.Models.ViewModels.Message
{
    public class RecentChatViewModel
    {
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string ReceiverUserName { get; set; }
        public string ReceiverPhotoURL { get; set; }
        public string LastMessage { get; set; }
        public string ProductImgURL { get; set; }
    }
}
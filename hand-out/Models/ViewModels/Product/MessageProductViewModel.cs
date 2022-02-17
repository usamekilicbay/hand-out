namespace hand_out.Models.ViewModels.Product
{
    public class MessageProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoURL { get; set; }
        public string GrantorId { get; set; }
        public string GrantorUserName { get; set; }
        public string GrantorProfilePhotoURL { get; set; }

        public string GetThumbnailURL()
        {
            return PhotoURL.Split("|")[0];
        }
    }
}
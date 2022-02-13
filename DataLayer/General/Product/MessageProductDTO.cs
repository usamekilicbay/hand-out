namespace DataLayer.Product
{
    public class MessageProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoURL { get; set; }
        public string GrantorId { get; set; }
        public string GrantorUserName { get; set; }
        public string GrantorProfilePhotoURL { get; set; }
    }
}
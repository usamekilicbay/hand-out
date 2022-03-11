using static Sidekick.NET.Types;

namespace DataLayer.User
{
    public class DetailsUserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ProfilePhotoURL { get; set; }
        public UserStatus Status { get; set; }
    }
}
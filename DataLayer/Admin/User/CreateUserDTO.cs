using System.ComponentModel.DataAnnotations;
using static Sidekick.NET.Types;

namespace DataLayer.Areas.Admin.User
{
    public class CreateUserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Display(Name = "Profile Photo URL")]
        public string ProfilePhotoURL { get; set; }
        public UserStatus Status { get; set; }
    }
}
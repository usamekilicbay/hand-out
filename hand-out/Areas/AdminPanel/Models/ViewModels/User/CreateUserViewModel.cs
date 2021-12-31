using System.ComponentModel.DataAnnotations;
using static Sidekick.NET.Types;

namespace hand_out.Areas.AdminPanel.Models.ViewModels.User
{
    public class CreateUserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Display(Name = "Profile Photo URL")]
        public string ProfilePhotoURL { get; set; }
        public UserStatus Status { get; set; }
    }
}

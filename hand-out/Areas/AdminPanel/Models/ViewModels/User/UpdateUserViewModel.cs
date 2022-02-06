using System;
using System.ComponentModel.DataAnnotations;
using static Sidekick.NET.Types;

namespace hand_out.Areas.Admin.Models.ViewModels.User
{
    public class UpdateUserViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Display(Name = "Profile Photo URL")]
        public string ProfilePhotoURL { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Date Modified")]
        public DateTime DateModified { get; set; }
        [Display(Name = "Last Seen")]
        public DateTime LastSeen { get; set; }
        public UserStatus Status { get; set; }
    }
}

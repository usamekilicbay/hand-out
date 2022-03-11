using hand_out.Models.ViewModels.Product;
using System.Collections.Generic;
using static Sidekick.NET.Types;

namespace hand_out.Models.ViewModels.User
{
    public class DetailsUserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ProfilePhotoURL { get; set; }
        public UserStatus Status { get; set; }
    }
}
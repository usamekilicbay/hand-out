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

        public virtual IList<EntityLayer.Concrete.Product> Products { get; set; }
    }
}

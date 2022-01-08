using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using static Sidekick.NET.Types;

namespace EntityLayer.Concrete
{
    public class User : IdentityUser
    {
        public string Address { get; set; }
        public string ProfilePhotoURL { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime LastSeen { get; set; }
        public UserStatus Status { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

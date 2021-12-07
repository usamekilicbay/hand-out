using System;
using System.Collections.Generic;
using static Sidekick.NET.Types;

namespace EntityLayer.Concrete
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string ProfilePhotoLink { get; set; }
        public string Address { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastSeen { get; set; }
        public UserStatus Status { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

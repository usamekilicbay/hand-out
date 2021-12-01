using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Sidekick.NET.Types;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Mail { get; set; }
        public string ProfilePhotoLink { get; set; }
        public string Adress { get; set; }
        public ICollection<Product> Products { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastSeen { get; set; }
        public UserStatus Status { get; set; }
    }
}

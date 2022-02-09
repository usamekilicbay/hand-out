using System;
using static Sidekick.NET.Types;

namespace DataLayer.Areas.Admin.User
{
    public class ListUserDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ProfilePhotoURL { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime LastSeen { get; set; }
        public UserStatus Status { get; set; }
    }
}
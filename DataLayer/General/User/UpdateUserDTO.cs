using Microsoft.AspNetCore.Http;
using System;
using static Sidekick.NET.Types;

namespace DataLayer.General.User
{
    public class UpdateUserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public IFormFile PhotoFile { get; set; }
        public DateTime LastSeen { get; set; }
        public UserStatus Status { get; set; }
    }
}
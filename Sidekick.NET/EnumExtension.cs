using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sidekick.NET.Types;

namespace Sidekick.NET
{
    public static class EnumExtension
    {
        public static UserStatus GetUserStatus(bool status) => 
            (UserStatus)Convert.ToInt32(status);

        public static UserActivityStatus GetUserActivityStatus(bool status) =>
            (UserActivityStatus)Convert.ToInt32(status);
    }
}

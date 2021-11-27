using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidekick.NET
{
    public static class Types
    {
        public enum UserStatus
        {
            ACTIVE,
            BANNED,
            PASSIVE,
        }

        public enum UserActivityStatus
        {
            OFFLINE,
            ONLINE
        }

        public enum SessionRole
        {
            NON,
            STUDENT,
            TEACHER,
            ADMIN
        }

        public enum SessionOperation
        {
            START,
            END
        }
    }
}

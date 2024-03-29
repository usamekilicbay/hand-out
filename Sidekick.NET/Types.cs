﻿namespace Sidekick.NET
{
    public static class Types
    {
        public enum UserStatus
        {
            ACTIVE,
            BANNED,
            OFFLINE,
            ONLINE,
            PASSIVE,
            PENDING,
        }

        public enum ProductStatus
        {
            ACTIVE,
            GIVEN,
            PASSIVE,
        }

        public enum CategoryStatus
        {
            ACTIVE,
            PASSIVE
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
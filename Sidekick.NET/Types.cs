namespace Sidekick.NET
{
    public static class Types
    {
        public enum UserStatus : byte
        {
            ACTIVE,
            BANNED,
            PASSIVE,
        }

        public enum UserActivityStatus : byte
        {
            OFFLINE,
            ONLINE
        }

        public enum ProductStatus : byte
        {
            ACTIVE,
            GIVEN,
            PASSIVE,
        }

        public enum CategoryStatus : byte
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

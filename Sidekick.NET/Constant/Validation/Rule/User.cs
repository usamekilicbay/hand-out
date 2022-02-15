using Sidekick.NET.Constant.SQL;
using static Sidekick.NET.Types;

namespace Sidekick.NET.Constant.Validation.Rule
{
    public static class User
    {
        public static class Name
        {
            public const int MIN_LENGTH = 2;
            public const int MAX_LENGTH = 20;
        }

        public static class Email
        {
            public const int MAX_LENGTH = 507;
        }

        public static class Address
        {
            public const int MAX_LENGTH = 200;
        }

        public static class ProfilePhotoURL
        {
            public const int MAX_LENGTH = 1000;
        }

        public static class LastSeen
        {
            public const string DATA_TYPE = DataType.DateAndTime.SMALLDATETIME;
            public const string DEFAULT_VALUE_SQL = DefaultValueSQL.GET_DATE;
        }

        public static class DateCreated
        {
            public const string DATA_TYPE = DataType.DateAndTime.DATE;
            public const string DEFAULT_VALUE_SQL = DefaultValueSQL.GET_DATE;
        }

        public static class DateModified
        {
            public const string DATA_TYPE = DataType.DateAndTime.DATE;
            public const string DEFAULT_VALUE_SQL = DefaultValueSQL.GET_DATE;
        }

        public static class Status
        {
            public const string DATA_TYPE = DataType.ExactNumeric.TINYINT;
            public const UserStatus DEFAULT_VALUE = UserStatus.ACTIVE;
        }
    }
}
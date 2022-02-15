using Sidekick.NET.Constant.SQL;
using static Sidekick.NET.Types;

namespace Sidekick.NET.Constant.Validation.Rule
{
    public static class Category
    {
        public static class Name
        {
            public const int MIN_LENGTH = 2;
            public const int MAX_LENGTH = 20;
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
            public const CategoryStatus DEFAULT_VALUE = CategoryStatus.ACTIVE;
        }

        public static class FontAwesomeIconName
        {
            public const int MIN_LENGTH = 4;
            public const int MAX_LENGTH = 20;
        }
    }
}
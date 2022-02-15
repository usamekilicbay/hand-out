using Sidekick.NET.Constant.SQL;
using static Sidekick.NET.Types;

namespace Sidekick.NET.Constant.Validation.Rule
{
    public static class Product
    {
        public class Name
        {
            public const int MIN_LENGTH = 2;
            public const int MAX_LENGTH = 20;
        }

        public class Details
        {
            public const int MAX_LENGTH = 1000;
        }

        public class Address
        {
            public const int MAX_LENGTH = 200;
        }

        public class PhotoURL
        {
            public const int MAX_LENGTH = 5000;
        }

        public static class DatePublished
        {
            public const string DATA_TYPE = DataType.DateAndTime.DATE;
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

        public class Status
        {
            public const string DATA_TYPE = DataType.ExactNumeric.TINYINT;
            public const ProductStatus DEFAULT_VALUE = ProductStatus.ACTIVE;
        }
    }
}
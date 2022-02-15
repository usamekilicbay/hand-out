using Sidekick.NET.Constant.SQL;

namespace Sidekick.NET.Constant.Validation.Rule
{
    public class Message
    {
        public static class Id
        {
            public const string DEFAULT_VALUE_SQL = DefaultValueSQL.NEW_ID;
        }

        public static class DateSent
        {
            public const string DATA_TYPE = DataType.DateAndTime.DATETIME;
            public const string DEFAULT_VALUE_SQL = DefaultValueSQL.GET_DATE;
        }
    }
}
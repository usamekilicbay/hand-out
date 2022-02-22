using Sidekick.NET.Constant.SQL;

namespace Sidekick.NET.Constant.Validation.Rule
{
    public class Chat
    {
        public static class Id
        {
            public const string DEFAULT_VALUE_SQL = DefaultValueSQL.NEW_ID;
        }

        public static class DateCreated
        {
            public const string DATA_TYPE = DataType.DateAndTime.SMALLDATETIME;
            public const string DEFAULT_VALUE_SQL = DefaultValueSQL.GET_DATE;
        }
    }
}
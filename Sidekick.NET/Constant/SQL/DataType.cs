namespace Sidekick.NET.Constant.SQL
{
    public static class DataType
    {
        public static class ExactNumeric
        {
            public const string BIGINT = "bigint";
            public const string NUMERIC = "numeric";
            public const string BIT = "bit";
            public const string SMALLINT = "smallint";
            public const string DECIMAL = "decimal";
            public const string SMALLMONEY = "smallmoney";
            public const string INT = "int";
            public const string TINYINT = "tinyint";
            public const string MONEY = "money";
        }

        public static class ApproximateNumeric
        {
            public const string FLOAT = "float";
            public const string REAL = "real";
        }

        public static class DateAndTime
        {
            public const string DATE = "date";
            public const string DATETIMEOFFSET = "datetimeoffset";
            public const string DATETIME2 = "datetime2";
            public const string SMALLDATETIME = "smalldatetime";
            public const string DATETIME = "datetime";
            public const string TIME = "time";
        }

        public static class CharacterString
        {
            public const string CHAR = "char";
            public const string VARCHAR = "varchar";
            public const string TEXT = "text";
        }

        public static class UnicodeCharacterString
        {
            public const string NCHAR = "nchar";
            public const string NVARCHAR = "nvarchar";
            public const string NTEXT = "ntext";
        }

        public static class BinaryString
        {
            public const string BINARY = "binary";
            public const string VARBINARY = "varbinary";
            public const string IMAGE = "image";
        }

        public static class OtherDataType
        {
            public const string CURSOR = "cursor";
            public const string ROWVERSION = "rowversion";
            public const string HIERARCHYID = "hierarchyid";
            public const string UNIQUEIDENTIFIER = "uniqueidentifier";
            public const string SQL_VARIANT = "sql_variant";
            public const string XML    = "xml";
            public const string TABLE = "table";
        }
    }
}

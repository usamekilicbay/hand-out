using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class UpdateIdColumnDefaultValueAsDefaultValueSqlMessageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Message",
                type: "nvarchar(450)",
                nullable: false,
                defaultValueSql: "newid()",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "newid()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Message",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "newid()",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValueSql: "newid()");
        }
    }
}

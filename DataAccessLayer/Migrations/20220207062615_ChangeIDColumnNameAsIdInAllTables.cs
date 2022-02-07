using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class ChangeIDColumnNameAsIdInAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Product",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Category",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Message",
                type: "nvarchar(450)",
                nullable: false,
                defaultValueSql: "NewId()",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValueSql: "newid()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Product",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Category",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Message",
                type: "nvarchar(450)",
                nullable: false,
                defaultValueSql: "newid()",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValueSql: "NewId()");
        }
    }
}

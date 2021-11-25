using Microsoft.EntityFrameworkCore.Migrations;

namespace hand_out.Migrations
{
    public partial class RemoveGrantorAndNeederFromProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_User_GrantorID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_User_NeederID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_GrantorID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_NeederID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "GrantorID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "NeederID",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GrantorID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NeederID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_GrantorID",
                table: "Product",
                column: "GrantorID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_NeederID",
                table: "Product",
                column: "NeederID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User_GrantorID",
                table: "Product",
                column: "GrantorID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User_NeederID",
                table: "Product",
                column: "NeederID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

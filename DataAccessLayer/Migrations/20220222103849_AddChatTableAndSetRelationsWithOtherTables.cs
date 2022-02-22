using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddChatTableAndSetRelationsWithOtherTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Product_ProductId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_ProductId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Message");

            migrationBuilder.AddColumn<string>(
                name: "ChatId",
                table: "Message",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "NewId()"),
                    DateCreated = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValueSql: "GetDate()"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    GrantorParticipantId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NeedyParticipantId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chat_AspNetUsers_GrantorParticipantId",
                        column: x => x.GrantorParticipantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chat_AspNetUsers_NeedyParticipantId",
                        column: x => x.NeedyParticipantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chat_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message_ChatId",
                table: "Message",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_GrantorParticipantId",
                table: "Chat",
                column: "GrantorParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_NeedyParticipantId",
                table: "Chat",
                column: "NeedyParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_ProductId",
                table: "Chat",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Chat_ChatId",
                table: "Message",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Chat_ChatId",
                table: "Message");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropIndex(
                name: "IX_Message_ChatId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "ChatId",
                table: "Message");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Message",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Message_ProductId",
                table: "Message",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Product_ProductId",
                table: "Message",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

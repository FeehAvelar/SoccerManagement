using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerManagement.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFinancialWhoChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financial_User_WhoChangeId",
                table: "Financial");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_User_IdWhoChange",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Financial_WhoChangeId",
                table: "Financial");

            migrationBuilder.DropColumn(
                name: "WhoChangeId",
                table: "Financial");

            migrationBuilder.CreateIndex(
                name: "IX_Financial_IdWhoChange",
                table: "Financial",
                column: "IdWhoChange");

            migrationBuilder.AddForeignKey(
                name: "FK_Financial_User_IdWhoChange",
                table: "Financial",
                column: "IdWhoChange",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_User_IdWhoChange",
                table: "Game",
                column: "IdWhoChange",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financial_User_IdWhoChange",
                table: "Financial");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_User_IdWhoChange",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Financial_IdWhoChange",
                table: "Financial");

            migrationBuilder.AddColumn<int>(
                name: "WhoChangeId",
                table: "Financial",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Financial_WhoChangeId",
                table: "Financial",
                column: "WhoChangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Financial_User_WhoChangeId",
                table: "Financial",
                column: "WhoChangeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_User_IdWhoChange",
                table: "Game",
                column: "IdWhoChange",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}

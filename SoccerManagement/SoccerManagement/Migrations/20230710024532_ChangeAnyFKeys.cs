using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerManagement.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAnyFKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_financial_Player_WhoChangeId",
                table: "financial");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Player_IdWhoChange",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Player_WhoChangeId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Player_WhoChangeId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_WhoChangeId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Player_WhoChangeId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "WhoChangeId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "WhoChangeId",
                table: "Player");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId1",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_PlayerId1",
                table: "User",
                column: "PlayerId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_financial_User_WhoChangeId",
                table: "financial",
                column: "WhoChangeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_User_IdWhoChange",
                table: "Game",
                column: "IdWhoChange",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Player_PlayerId1",
                table: "User",
                column: "PlayerId1",
                principalTable: "Player",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_financial_User_WhoChangeId",
                table: "financial");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_User_IdWhoChange",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Player_PlayerId1",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_PlayerId1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PlayerId1",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "WhoChangeId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WhoChangeId",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_WhoChangeId",
                table: "User",
                column: "WhoChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_WhoChangeId",
                table: "Player",
                column: "WhoChangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_financial_Player_WhoChangeId",
                table: "financial",
                column: "WhoChangeId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Player_IdWhoChange",
                table: "Game",
                column: "IdWhoChange",
                principalTable: "Player",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Player_WhoChangeId",
                table: "Player",
                column: "WhoChangeId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Player_WhoChangeId",
                table: "User",
                column: "WhoChangeId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

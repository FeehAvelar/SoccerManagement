using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerManagement.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEntitiesCreatorRule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financial_Player_CreatorId",
                table: "Financial");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Player_IdCreator",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_User_IdWhoChange",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_User_IdWhoChange",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Game_IdCreator",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Financial_CreatorId",
                table: "Financial");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Financial");

            migrationBuilder.CreateIndex(
                name: "IX_Game_IdCreator",
                table: "Game",
                column: "IdCreator",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Financial_IdCreator",
                table: "Financial",
                column: "IdCreator",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Financial_Player_IdCreator",
                table: "Financial",
                column: "IdCreator",
                principalTable: "Player",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Player_IdCreator",
                table: "Game",
                column: "IdCreator",
                principalTable: "Player",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_User_IdWhoChange",
                table: "Game",
                column: "IdWhoChange",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_User_IdWhoChange",
                table: "Player",
                column: "IdWhoChange",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financial_Player_IdCreator",
                table: "Financial");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Player_IdCreator",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_User_IdWhoChange",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_User_IdWhoChange",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Game_IdCreator",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Financial_IdCreator",
                table: "Financial");

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Financial",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Game_IdCreator",
                table: "Game",
                column: "IdCreator");

            migrationBuilder.CreateIndex(
                name: "IX_Financial_CreatorId",
                table: "Financial",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Financial_Player_CreatorId",
                table: "Financial",
                column: "CreatorId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Player_IdCreator",
                table: "Game",
                column: "IdCreator",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_User_IdWhoChange",
                table: "Game",
                column: "IdWhoChange",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_User_IdWhoChange",
                table: "Player",
                column: "IdWhoChange",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

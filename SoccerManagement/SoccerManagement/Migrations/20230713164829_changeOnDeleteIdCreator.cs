using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerManagement.Migrations
{
    /// <inheritdoc />
    public partial class changeOnDeleteIdCreator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Player_IdCreator",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_IdCreator",
                table: "Game");

            migrationBuilder.CreateIndex(
                name: "IX_Game_IdCreator",
                table: "Game",
                column: "IdCreator");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Player_IdCreator",
                table: "Game",
                column: "IdCreator",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Player_IdCreator",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_IdCreator",
                table: "Game");

            migrationBuilder.CreateIndex(
                name: "IX_Game_IdCreator",
                table: "Game",
                column: "IdCreator",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Player_IdCreator",
                table: "Game",
                column: "IdCreator",
                principalTable: "Player",
                principalColumn: "Id");
        }
    }
}

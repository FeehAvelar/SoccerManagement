using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerManagement.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOnDeletePlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_User_WhoChangeId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_WhoChangeId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "WhoChangeId",
                table: "Player");

            migrationBuilder.CreateIndex(
                name: "IX_Player_IdWhoChange",
                table: "Player",
                column: "IdWhoChange",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_User_IdWhoChange",
                table: "Player",
                column: "IdWhoChange",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_User_IdWhoChange",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_IdWhoChange",
                table: "Player");

            migrationBuilder.AddColumn<int>(
                name: "WhoChangeId",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Player_WhoChangeId",
                table: "Player",
                column: "WhoChangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_User_WhoChangeId",
                table: "Player",
                column: "WhoChangeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

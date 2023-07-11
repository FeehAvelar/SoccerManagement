using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerManagement.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Player_PlayerId1",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_PlayerId1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PlayerId1",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "User",
                newName: "IdPlayer");

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
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "IdPlayer",
                table: "User",
                newName: "PlayerId");

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
                name: "FK_User_Player_PlayerId1",
                table: "User",
                column: "PlayerId1",
                principalTable: "Player",
                principalColumn: "Id");
        }
    }
}

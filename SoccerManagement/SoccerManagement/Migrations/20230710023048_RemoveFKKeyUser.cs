using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerManagement.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFKKeyUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_User_IdUser",
                table: "Player");

            migrationBuilder.AlterColumn<int>(
                name: "IdUser",
                table: "Player",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_User_IdUser",
                table: "Player",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_User_IdUser",
                table: "Player");

            migrationBuilder.AlterColumn<int>(
                name: "IdUser",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_User_IdUser",
                table: "Player",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

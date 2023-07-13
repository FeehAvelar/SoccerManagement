using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerManagement.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFinancialWhoChange2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financial_User_IdWhoChange",
                table: "Financial");

            migrationBuilder.AddForeignKey(
                name: "FK_Financial_User_IdWhoChange",
                table: "Financial",
                column: "IdWhoChange",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financial_User_IdWhoChange",
                table: "Financial");

            migrationBuilder.AddForeignKey(
                name: "FK_Financial_User_IdWhoChange",
                table: "Financial",
                column: "IdWhoChange",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

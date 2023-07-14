using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerManagement.Migrations
{
    /// <inheritdoc />
    public partial class AjusteFinancialFKCreator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financial_Player_IdCreator",
                table: "Financial");

            migrationBuilder.DropIndex(
                name: "IX_Financial_IdCreator",
                table: "Financial");

            migrationBuilder.CreateIndex(
                name: "IX_Financial_IdCreator",
                table: "Financial",
                column: "IdCreator");

            migrationBuilder.AddForeignKey(
                name: "FK_Financial_Player_IdCreator",
                table: "Financial",
                column: "IdCreator",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financial_Player_IdCreator",
                table: "Financial");

            migrationBuilder.DropIndex(
                name: "IX_Financial_IdCreator",
                table: "Financial");

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
        }
    }
}

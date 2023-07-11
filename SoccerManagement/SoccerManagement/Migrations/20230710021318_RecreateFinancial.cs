using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerManagement.Migrations
{
    /// <inheritdoc />
    public partial class RecreateFinancial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Player_IdWhoChange",
                table: "Game");

            migrationBuilder.RenameColumn(
                name: "Passworld",
                table: "User",
                newName: "Password");

            migrationBuilder.AlterColumn<int>(
                name: "IdWhoChange",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdWhoChange",
                table: "Player",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdWhoChange",
                table: "Game",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "financial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdOwner = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    DateAdd = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IdWhoChange = table.Column<int>(type: "int", nullable: true),
                    WhoChangeId = table.Column<int>(type: "int", nullable: false),
                    IdOrigin = table.Column<int>(type: "int", nullable: false),
                    FinanceOrigin = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    TypeFinance = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DatePayment = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_financial_Player_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_financial_Player_WhoChangeId",
                        column: x => x.WhoChangeId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_financial_OwnerId",
                table: "financial",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_financial_WhoChangeId",
                table: "financial",
                column: "WhoChangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Player_IdWhoChange",
                table: "Game",
                column: "IdWhoChange",
                principalTable: "Player",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Player_IdWhoChange",
                table: "Game");

            migrationBuilder.DropTable(
                name: "financial");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "Passworld");

            migrationBuilder.AlterColumn<int>(
                name: "IdWhoChange",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdWhoChange",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdWhoChange",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Player_IdWhoChange",
                table: "Game",
                column: "IdWhoChange",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerManagement.Migrations
{
    /// <inheritdoc />
    public partial class CreateEnities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WhoChange",
                table: "Player",
                newName: "WhoChangeId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdate",
                table: "Player",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdWhoChange",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateAdd = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IdWhoChange = table.Column<int>(type: "int", nullable: false),
                    IdOwner = table.Column<int>(type: "int", nullable: false),
                    DayAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    GameDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Player_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Game_Player_IdWhoChange",
                        column: x => x.IdWhoChange,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateAdd = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IdWhoChange = table.Column<int>(type: "int", nullable: false),
                    WhoChangeId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Passworld = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Player_WhoChangeId",
                        column: x => x.WhoChangeId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GamePlayers",
                columns: table => new
                {
                    FkGame = table.Column<int>(type: "int", nullable: false),
                    FkPlayer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayers", x => new { x.FkGame, x.FkPlayer });
                    table.ForeignKey(
                        name: "FK_GamePlayers_Game_FkGame",
                        column: x => x.FkGame,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlayers_Player_FkPlayer",
                        column: x => x.FkPlayer,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Player_IdUser",
                table: "Player",
                column: "IdUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_WhoChangeId",
                table: "Player",
                column: "WhoChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_IdOwner",
                table: "Game",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Game_IdWhoChange",
                table: "Game",
                column: "IdWhoChange");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayers_FkPlayer",
                table: "GamePlayers",
                column: "FkPlayer");

            migrationBuilder.CreateIndex(
                name: "IX_User_WhoChangeId",
                table: "User",
                column: "WhoChangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Player_WhoChangeId",
                table: "Player",
                column: "WhoChangeId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_User_IdUser",
                table: "Player",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Player_WhoChangeId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_User_IdUser",
                table: "Player");

            migrationBuilder.DropTable(
                name: "GamePlayers");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Player_IdUser",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_WhoChangeId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "IdWhoChange",
                table: "Player");

            migrationBuilder.RenameColumn(
                name: "WhoChangeId",
                table: "Player",
                newName: "WhoChange");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdate",
                table: "Player",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);
        }
    }
}

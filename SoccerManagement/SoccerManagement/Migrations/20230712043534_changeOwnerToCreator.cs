using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerManagement.Migrations
{
    /// <inheritdoc />
    public partial class changeOwnerToCreator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_financial_Player_OwnerId",
                table: "financial");

            migrationBuilder.DropForeignKey(
                name: "FK_financial_User_WhoChangeId",
                table: "financial");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Player_IdOwner",
                table: "Game");

            migrationBuilder.DropPrimaryKey(
                name: "PK_financial",
                table: "financial");

            migrationBuilder.DropIndex(
                name: "IX_financial_OwnerId",
                table: "financial");

            migrationBuilder.RenameTable(
                name: "financial",
                newName: "Financial");

            migrationBuilder.RenameColumn(
                name: "IdOwner",
                table: "Game",
                newName: "IdCreator");

            migrationBuilder.RenameIndex(
                name: "IX_Game_IdOwner",
                table: "Game",
                newName: "IX_Game_IdCreator");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Financial",
                newName: "IdCreator");

            migrationBuilder.RenameColumn(
                name: "IdOwner",
                table: "Financial",
                newName: "IdAccountable");

            migrationBuilder.RenameIndex(
                name: "IX_financial_WhoChangeId",
                table: "Financial",
                newName: "IX_Financial_WhoChangeId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePayment",
                table: "Financial",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<int>(
                name: "AccountableId",
                table: "Financial",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Financial",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Financial",
                table: "Financial",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Financial_AccountableId",
                table: "Financial",
                column: "AccountableId");

            migrationBuilder.CreateIndex(
                name: "IX_Financial_CreatorId",
                table: "Financial",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Financial_Player_AccountableId",
                table: "Financial",
                column: "AccountableId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Financial_Player_CreatorId",
                table: "Financial",
                column: "CreatorId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Financial_User_WhoChangeId",
                table: "Financial",
                column: "WhoChangeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Financial_Player_AccountableId",
                table: "Financial");

            migrationBuilder.DropForeignKey(
                name: "FK_Financial_Player_CreatorId",
                table: "Financial");

            migrationBuilder.DropForeignKey(
                name: "FK_Financial_User_WhoChangeId",
                table: "Financial");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Player_IdCreator",
                table: "Game");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Financial",
                table: "Financial");

            migrationBuilder.DropIndex(
                name: "IX_Financial_AccountableId",
                table: "Financial");

            migrationBuilder.DropIndex(
                name: "IX_Financial_CreatorId",
                table: "Financial");

            migrationBuilder.DropColumn(
                name: "AccountableId",
                table: "Financial");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Financial");

            migrationBuilder.RenameTable(
                name: "Financial",
                newName: "financial");

            migrationBuilder.RenameColumn(
                name: "IdCreator",
                table: "Game",
                newName: "IdOwner");

            migrationBuilder.RenameIndex(
                name: "IX_Game_IdCreator",
                table: "Game",
                newName: "IX_Game_IdOwner");

            migrationBuilder.RenameColumn(
                name: "IdCreator",
                table: "financial",
                newName: "OwnerId");

            migrationBuilder.RenameColumn(
                name: "IdAccountable",
                table: "financial",
                newName: "IdOwner");

            migrationBuilder.RenameIndex(
                name: "IX_Financial_WhoChangeId",
                table: "financial",
                newName: "IX_financial_WhoChangeId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePayment",
                table: "financial",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_financial",
                table: "financial",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_financial_OwnerId",
                table: "financial",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_financial_Player_OwnerId",
                table: "financial",
                column: "OwnerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_financial_User_WhoChangeId",
                table: "financial",
                column: "WhoChangeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Player_IdOwner",
                table: "Game",
                column: "IdOwner",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

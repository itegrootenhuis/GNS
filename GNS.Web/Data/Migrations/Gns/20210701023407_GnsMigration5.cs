using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GNS.Web.Data.Migrations.Gns
{
    public partial class GnsMigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Records_RecordId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_RecordId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "Players");

            migrationBuilder.AddColumn<Guid>(
                name: "WinnerPlayerId",
                table: "Records",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Records_WinnerPlayerId",
                table: "Records",
                column: "WinnerPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Players_WinnerPlayerId",
                table: "Records",
                column: "WinnerPlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Players_WinnerPlayerId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_WinnerPlayerId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "WinnerPlayerId",
                table: "Records");

            migrationBuilder.AddColumn<Guid>(
                name: "RecordId",
                table: "Players",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_RecordId",
                table: "Players",
                column: "RecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Records_RecordId",
                table: "Players",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "RecordId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

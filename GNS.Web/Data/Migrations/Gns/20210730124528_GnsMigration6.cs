using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GNS.Web.Data.Migrations.Gns
{
    public partial class GnsMigration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "Records",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Records_GroupId",
                table: "Records",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Groups_GroupId",
                table: "Records",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Groups_GroupId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_GroupId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Records");
        }
    }
}

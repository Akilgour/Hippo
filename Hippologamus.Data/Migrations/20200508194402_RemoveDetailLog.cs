using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hippologamus.Data.Migrations
{
    public partial class RemoveDetailLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailLogComments_DetailLogs_DetailLogId1",
                table: "DetailLogComments");

            migrationBuilder.DropTable(
                name: "DetailLogs");

            migrationBuilder.DropIndex(
                name: "IX_DetailLogComments_DetailLogId1",
                table: "DetailLogComments");

            migrationBuilder.DropColumn(
                name: "DetailLogId1",
                table: "DetailLogComments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DetailLogId1",
                table: "DetailLogComments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DetailLogs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Assembly = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogEvent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailLogs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailLogComments_DetailLogId1",
                table: "DetailLogComments",
                column: "DetailLogId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailLogComments_DetailLogs_DetailLogId1",
                table: "DetailLogComments",
                column: "DetailLogId1",
                principalTable: "DetailLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

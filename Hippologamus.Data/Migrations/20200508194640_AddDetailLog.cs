using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hippologamus.Data.Migrations
{
    public partial class AddDetailLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetailLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Properties = table.Column<string>(nullable: true),
                    LogEvent = table.Column<string>(nullable: true),
                    MachineName = table.Column<string>(nullable: true),
                    Assembly = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailLogs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailLogComments_DetailLogId",
                table: "DetailLogComments",
                column: "DetailLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailLogComments_DetailLogs_DetailLogId",
                table: "DetailLogComments",
                column: "DetailLogId",
                principalTable: "DetailLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailLogComments_DetailLogs_DetailLogId",
                table: "DetailLogComments");

            migrationBuilder.DropTable(
                name: "DetailLogs");

            migrationBuilder.DropIndex(
                name: "IX_DetailLogComments_DetailLogId",
                table: "DetailLogComments");
        }
    }
}

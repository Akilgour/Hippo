using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hippologamus.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetailLogs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "PerfLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Properties = table.Column<string>(nullable: true),
                    LogEvent = table.Column<string>(nullable: true),
                    PerfItem = table.Column<string>(nullable: true),
                    ElapsedMilliseconds = table.Column<string>(nullable: true),
                    ActionName = table.Column<string>(nullable: true),
                    MachineName = table.Column<string>(nullable: true),
                    Assembly = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsageLogs",
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
                    table.PrimaryKey("PK_UsageLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetailLogComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(nullable: true),
                    DetailLogId = table.Column<int>(nullable: false),
                    DetailLogId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailLogComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailLogComments_DetailLogs_DetailLogId1",
                        column: x => x.DetailLogId1,
                        principalTable: "DetailLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailLogComments_DetailLogId1",
                table: "DetailLogComments",
                column: "DetailLogId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailLogComments");

            migrationBuilder.DropTable(
                name: "PerfLogs");

            migrationBuilder.DropTable(
                name: "UsageLogs");

            migrationBuilder.DropTable(
                name: "DetailLogs");
        }
    }
}

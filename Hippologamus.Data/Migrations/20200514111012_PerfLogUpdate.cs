using Microsoft.EntityFrameworkCore.Migrations;

namespace Hippologamus.Data.Migrations
{
    public partial class PerfLogUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "PerfLogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "PerfLogs");
        }
    }
}

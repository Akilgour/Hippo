using Microsoft.EntityFrameworkCore.Migrations;

namespace Hippologamus.Data.Migrations
{
    public partial class PerfLog_AddRequestPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RequestPath",
                table: "PerfLogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestPath",
                table: "PerfLogs");
        }
    }
}

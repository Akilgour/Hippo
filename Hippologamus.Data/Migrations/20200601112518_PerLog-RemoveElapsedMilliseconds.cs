using Microsoft.EntityFrameworkCore.Migrations;

namespace Hippologamus.Data.Migrations
{
    public partial class PerLogRemoveElapsedMilliseconds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElapsedMilliseconds",
                table: "PerfLogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ElapsedMilliseconds",
                table: "PerfLogs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

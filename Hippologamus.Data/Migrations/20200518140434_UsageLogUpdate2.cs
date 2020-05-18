using Microsoft.EntityFrameworkCore.Migrations;

namespace Hippologamus.Data.Migrations
{
    public partial class UsageLogUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RequestPath",
                table: "UsageLogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestPath",
                table: "UsageLogs");
        }
    }
}

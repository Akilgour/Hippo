using Microsoft.EntityFrameworkCore.Migrations;

namespace Hippologamus.Data.Migrations
{
    public partial class DetailLogUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Exception",
                table: "DetailLogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestPath",
                table: "DetailLogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exception",
                table: "DetailLogs");

            migrationBuilder.DropColumn(
                name: "RequestPath",
                table: "DetailLogs");
        }
    }
}

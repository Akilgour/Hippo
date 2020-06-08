using Microsoft.EntityFrameworkCore.Migrations;

namespace Hippologamus.Data.Migrations
{
    public partial class UpdateDetailLogComment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DevOpsId",
                table: "DetailLogComments",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LinkedToDevOps",
                table: "DetailLogComments",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DevOpsId",
                table: "DetailLogComments");

            migrationBuilder.DropColumn(
                name: "LinkedToDevOps",
                table: "DetailLogComments");
        }
    }
}

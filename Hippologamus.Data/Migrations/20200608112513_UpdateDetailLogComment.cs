using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hippologamus.Data.Migrations
{
    public partial class UpdateDetailLogComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateOn",
                table: "DetailLogComments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateadBy",
                table: "DetailLogComments",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OpenState",
                table: "DetailLogComments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "DetailLogComments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateOn",
                table: "DetailLogComments");

            migrationBuilder.DropColumn(
                name: "CreateadBy",
                table: "DetailLogComments");

            migrationBuilder.DropColumn(
                name: "OpenState",
                table: "DetailLogComments");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "DetailLogComments");
        }
    }
}

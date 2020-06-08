using Microsoft.EntityFrameworkCore.Migrations;

namespace ChargeApi.Migrations
{
    public partial class modifymenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuUrl",
                table: "menus");

            migrationBuilder.AddColumn<string>(
                name: "MenuPath",
                table: "menus",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParentName",
                table: "menus",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuPath",
                table: "menus");

            migrationBuilder.DropColumn(
                name: "ParentName",
                table: "menus");

            migrationBuilder.AddColumn<string>(
                name: "MenuUrl",
                table: "menus",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

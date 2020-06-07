using Microsoft.EntityFrameworkCore.Migrations;

namespace ChargeApi.Migrations
{
    public partial class modifyvehicleentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Guider",
                table: "chargeRecords",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleType",
                table: "chargeRecords",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guider",
                table: "chargeRecords");

            migrationBuilder.DropColumn(
                name: "VehicleType",
                table: "chargeRecords");
        }
    }
}

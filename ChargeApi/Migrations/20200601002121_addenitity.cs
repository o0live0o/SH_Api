using Microsoft.EntityFrameworkCore.Migrations;

namespace ChargeApi.Migrations
{
    public partial class addenitity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chargeDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlateNo = table.Column<string>(nullable: true),
                    TestNo = table.Column<string>(nullable: true),
                    TestItem = table.Column<string>(nullable: true),
                    TestTimes = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chargeDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "chargeRecords",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlateNo = table.Column<string>(nullable: true),
                    TestNo = table.Column<string>(nullable: true),
                    TestItem = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DateOfTest = table.Column<string>(nullable: true),
                    DateOfCharge = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chargeRecords", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chargeDetails");

            migrationBuilder.DropTable(
                name: "chargeRecords");
        }
    }
}

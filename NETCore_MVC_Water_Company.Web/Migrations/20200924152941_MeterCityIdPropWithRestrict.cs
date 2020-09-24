using Microsoft.EntityFrameworkCore.Migrations;

namespace NETCore_MVC_Water_Company.Web.Migrations
{
    public partial class MeterCityIdPropWithRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WaterMeters_CityId",
                table: "WaterMeters");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "WaterMeters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WaterMeters_CityId",
                table: "WaterMeters",
                column: "CityId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WaterMeters_CityId",
                table: "WaterMeters");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "WaterMeters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_WaterMeters_CityId",
                table: "WaterMeters",
                column: "CityId");
        }
    }
}

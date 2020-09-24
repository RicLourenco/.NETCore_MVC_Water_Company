using Microsoft.EntityFrameworkCore.Migrations;

namespace NETCore_MVC_Water_Company.Web.Migrations
{
    public partial class RevertPreviousMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaterMeters_Cities_CityId",
                table: "WaterMeters");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "WaterMeters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_WaterMeters_Cities_CityId",
                table: "WaterMeters",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaterMeters_Cities_CityId",
                table: "WaterMeters");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "WaterMeters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WaterMeters_Cities_CityId",
                table: "WaterMeters",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

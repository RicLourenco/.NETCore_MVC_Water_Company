using Microsoft.EntityFrameworkCore.Migrations;

namespace NETCore_MVC_Water_Company.Web.Migrations
{
    public partial class UserMeterCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaterMeters_AspNetUsers_UserId",
                table: "WaterMeters");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DocumentNumber_TIN",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "WaterMeters",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "WaterMeters",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "IBAN",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WaterMeters_Address_ZipCode",
                table: "WaterMeters",
                columns: new[] { "Address", "ZipCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Steps_MinimumConsumption",
                table: "Steps",
                column: "MinimumConsumption",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DocumentNumber_TIN_IBAN",
                table: "AspNetUsers",
                columns: new[] { "DocumentNumber", "TIN", "IBAN" },
                unique: true,
                filter: "[IBAN] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_WaterMeters_AspNetUsers_UserId",
                table: "WaterMeters",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaterMeters_AspNetUsers_UserId",
                table: "WaterMeters");

            migrationBuilder.DropIndex(
                name: "IX_WaterMeters_Address_ZipCode",
                table: "WaterMeters");

            migrationBuilder.DropIndex(
                name: "IX_Steps_MinimumConsumption",
                table: "Steps");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DocumentNumber_TIN_IBAN",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "WaterMeters",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "WaterMeters",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "IBAN",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DocumentNumber_TIN",
                table: "AspNetUsers",
                columns: new[] { "DocumentNumber", "TIN" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WaterMeters_AspNetUsers_UserId",
                table: "WaterMeters",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

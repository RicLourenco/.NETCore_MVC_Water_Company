using Microsoft.EntityFrameworkCore.Migrations;

namespace NETCore_MVC_Water_Company.Web.Migrations
{
    public partial class ChangePriceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Documents_DocumentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_WaterMeters_WaterMeterId",
                table: "Bills");

            migrationBuilder.AlterColumn<float>(
                name: "FinalValue",
                table: "Bills",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Documents_DocumentId",
                table: "AspNetUsers",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_WaterMeters_WaterMeterId",
                table: "Bills",
                column: "WaterMeterId",
                principalTable: "WaterMeters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Documents_DocumentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_WaterMeters_WaterMeterId",
                table: "Bills");

            migrationBuilder.AlterColumn<decimal>(
                name: "FinalValue",
                table: "Bills",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Documents_DocumentId",
                table: "AspNetUsers",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_WaterMeters_WaterMeterId",
                table: "Bills",
                column: "WaterMeterId",
                principalTable: "WaterMeters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

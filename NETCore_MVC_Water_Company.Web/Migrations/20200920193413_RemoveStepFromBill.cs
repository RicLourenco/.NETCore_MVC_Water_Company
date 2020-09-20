using Microsoft.EntityFrameworkCore.Migrations;

namespace NETCore_MVC_Water_Company.Web.Migrations
{
    public partial class RemoveStepFromBill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Steps_StepId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_StepId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "StepId",
                table: "Bills");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StepId",
                table: "Bills",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_StepId",
                table: "Bills",
                column: "StepId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Steps_StepId",
                table: "Bills",
                column: "StepId",
                principalTable: "Steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

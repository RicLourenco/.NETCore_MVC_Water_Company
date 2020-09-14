using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NETCore_MVC_Water_Company.Web.Migrations
{
    public partial class RemoveClientEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaterMeters_Clients_ClientId",
                table: "WaterMeters");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_WaterMeters_ClientId",
                table: "WaterMeters");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "WaterMeters");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "WaterMeters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IBAN",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WaterMeters_UserId",
                table: "WaterMeters",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WaterMeters_AspNetUsers_UserId",
                table: "WaterMeters",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaterMeters_AspNetUsers_UserId",
                table: "WaterMeters");

            migrationBuilder.DropIndex(
                name: "IX_WaterMeters_UserId",
                table: "WaterMeters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WaterMeters");

            migrationBuilder.DropColumn(
                name: "IBAN",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "WaterMeters",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IBAN = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaterMeters_ClientId",
                table: "WaterMeters",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WaterMeters_Clients_ClientId",
                table: "WaterMeters",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

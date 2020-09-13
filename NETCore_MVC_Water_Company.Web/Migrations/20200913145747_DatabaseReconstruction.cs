using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NETCore_MVC_Water_Company.Web.Migrations
{
    public partial class DatabaseReconstruction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaterMeters_Locations_LocationId",
                table: "WaterMeters");

            migrationBuilder.DropForeignKey(
                name: "FK_WaterMeters_AspNetUsers_UserId",
                table: "WaterMeters");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_WaterMeters_UserId",
                table: "WaterMeters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WaterMeters");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "WaterMeters",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_WaterMeters_LocationId",
                table: "WaterMeters",
                newName: "IX_WaterMeters_ClientId");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "WaterMeters",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "WaterMeters",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MeterState",
                table: "WaterMeters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "WaterMeters",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "FinalValue",
                table: "Bills",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "PaymentState",
                table: "Bills",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StepId",
                table: "Bills",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte>(
                name: "Gender",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "TIN",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

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
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    ContractNumber = table.Column<string>(nullable: true),
                    IBAN = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaximumConsumption = table.Column<float>(nullable: false),
                    Price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaterMeters_CityId",
                table: "WaterMeters",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_StepId",
                table: "Bills",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DocumentId",
                table: "AspNetUsers",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DocumentNumber_TIN",
                table: "AspNetUsers",
                columns: new[] { "DocumentNumber", "TIN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Documents_DocumentId",
                table: "AspNetUsers",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Steps_StepId",
                table: "Bills",
                column: "StepId",
                principalTable: "Steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WaterMeters_Cities_CityId",
                table: "WaterMeters",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WaterMeters_Clients_ClientId",
                table: "WaterMeters",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Documents_DocumentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Steps_StepId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_WaterMeters_Cities_CityId",
                table: "WaterMeters");

            migrationBuilder.DropForeignKey(
                name: "FK_WaterMeters_Clients_ClientId",
                table: "WaterMeters");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropIndex(
                name: "IX_WaterMeters_CityId",
                table: "WaterMeters");

            migrationBuilder.DropIndex(
                name: "IX_Bills_StepId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DocumentId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DocumentNumber_TIN",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "WaterMeters");

            migrationBuilder.DropColumn(
                name: "MeterState",
                table: "WaterMeters");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "WaterMeters");

            migrationBuilder.DropColumn(
                name: "FinalValue",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "PaymentState",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "StepId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TIN",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "WaterMeters",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_WaterMeters_ClientId",
                table: "WaterMeters",
                newName: "IX_WaterMeters_LocationId");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "WaterMeters",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "WaterMeters",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaterMeters_UserId",
                table: "WaterMeters",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WaterMeters_Locations_LocationId",
                table: "WaterMeters",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

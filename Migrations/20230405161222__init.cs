using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TEST_TPLUS.Migrations
{
    public partial class _init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    ConsumerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.ConsumerId);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    ConsumerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: true),
                    Consumption = table.Column<float>(type: "real", nullable: true),
                    PlantConsumerId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.ConsumerId);
                    table.ForeignKey(
                        name: "FK_Plants_Plants_PlantConsumerId",
                        column: x => x.PlantConsumerId,
                        principalTable: "Plants",
                        principalColumn: "ConsumerId");
                });

            migrationBuilder.CreateTable(
                name: "HouseConsumptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weather = table.Column<double>(type: "float", nullable: false),
                    Consumption = table.Column<double>(type: "float", nullable: false),
                    HouseConsumerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseConsumptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseConsumptions_Houses_HouseConsumerId",
                        column: x => x.HouseConsumerId,
                        principalTable: "Houses",
                        principalColumn: "ConsumerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HouseConsumptions_HouseConsumerId",
                table: "HouseConsumptions",
                column: "HouseConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_PlantConsumerId",
                table: "Plants",
                column: "PlantConsumerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseConsumptions");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Houses");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalGarden.Presentation.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gardener",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gardener", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Garden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GardenerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garden", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Garden_Gardener_GardenerId",
                        column: x => x.GardenerId,
                        principalTable: "Gardener",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantType = table.Column<int>(type: "int", nullable: false),
                    CommonName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ScientificName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PlantingSeason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrowthCycle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SunlightRequirement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WateringFrequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoilTypePreference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GardenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plant_Garden_GardenId",
                        column: x => x.GardenId,
                        principalTable: "Garden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    GardenId = table.Column<int>(type: "int", nullable: true),
                    PlantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceTask_Garden_GardenId",
                        column: x => x.GardenId,
                        principalTable: "Garden",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaintenanceTask_Plant_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plant",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlantRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatePlanted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PlantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantRecord_Plant_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrowthStage = table.Column<int>(type: "int", nullable: false),
                    ReviewTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PlantRecordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_PlantRecord_PlantRecordId",
                        column: x => x.PlantRecordId,
                        principalTable: "PlantRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Garden_GardenerId",
                table: "Garden",
                column: "GardenerId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceTask_GardenId",
                table: "MaintenanceTask",
                column: "GardenId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceTask_PlantId",
                table: "MaintenanceTask",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Plant_GardenId",
                table: "Plant",
                column: "GardenId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantRecord_PlantId",
                table: "PlantRecord",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_PlantRecordId",
                table: "Review",
                column: "PlantRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceTask");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "PlantRecord");

            migrationBuilder.DropTable(
                name: "Plant");

            migrationBuilder.DropTable(
                name: "Garden");

            migrationBuilder.DropTable(
                name: "Gardener");
        }
    }
}

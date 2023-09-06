using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalGarden.Presentation.Migrations
{
    /// <inheritdoc />
    public partial class CreatedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garden_Gardener_GardenerId",
                table: "Garden");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceTask_Garden_GardenId",
                table: "MaintenanceTask");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceTask_Plant_PlantId",
                table: "MaintenanceTask");

            migrationBuilder.DropForeignKey(
                name: "FK_Plant_Garden_GardenId",
                table: "Plant");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantRecord_Plant_PlantId",
                table: "PlantRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_PlantRecord_PlantRecordId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantRecord",
                table: "PlantRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plant",
                table: "Plant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaintenanceTask",
                table: "MaintenanceTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gardener",
                table: "Gardener");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Garden",
                table: "Garden");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "PlantRecord",
                newName: "PlantRecords");

            migrationBuilder.RenameTable(
                name: "Plant",
                newName: "Plants");

            migrationBuilder.RenameTable(
                name: "MaintenanceTask",
                newName: "MaintenanceTasks");

            migrationBuilder.RenameTable(
                name: "Gardener",
                newName: "Gardeners");

            migrationBuilder.RenameTable(
                name: "Garden",
                newName: "Gardens");

            migrationBuilder.RenameIndex(
                name: "IX_Review_PlantRecordId",
                table: "Reviews",
                newName: "IX_Reviews_PlantRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_PlantRecord_PlantId",
                table: "PlantRecords",
                newName: "IX_PlantRecords_PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_Plant_GardenId",
                table: "Plants",
                newName: "IX_Plants_GardenId");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceTask_PlantId",
                table: "MaintenanceTasks",
                newName: "IX_MaintenanceTasks_PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceTask_GardenId",
                table: "MaintenanceTasks",
                newName: "IX_MaintenanceTasks_GardenId");

            migrationBuilder.RenameIndex(
                name: "IX_Garden_GardenerId",
                table: "Gardens",
                newName: "IX_Gardens_GardenerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantRecords",
                table: "PlantRecords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plants",
                table: "Plants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaintenanceTasks",
                table: "MaintenanceTasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gardeners",
                table: "Gardeners",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gardens",
                table: "Gardens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gardens_Gardeners_GardenerId",
                table: "Gardens",
                column: "GardenerId",
                principalTable: "Gardeners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceTasks_Gardens_GardenId",
                table: "MaintenanceTasks",
                column: "GardenId",
                principalTable: "Gardens",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceTasks_Plants_PlantId",
                table: "MaintenanceTasks",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantRecords_Plants_PlantId",
                table: "PlantRecords",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Gardens_GardenId",
                table: "Plants",
                column: "GardenId",
                principalTable: "Gardens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_PlantRecords_PlantRecordId",
                table: "Reviews",
                column: "PlantRecordId",
                principalTable: "PlantRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gardens_Gardeners_GardenerId",
                table: "Gardens");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceTasks_Gardens_GardenId",
                table: "MaintenanceTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceTasks_Plants_PlantId",
                table: "MaintenanceTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantRecords_Plants_PlantId",
                table: "PlantRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Gardens_GardenId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_PlantRecords_PlantRecordId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plants",
                table: "Plants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantRecords",
                table: "PlantRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaintenanceTasks",
                table: "MaintenanceTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gardens",
                table: "Gardens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gardeners",
                table: "Gardeners");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameTable(
                name: "Plants",
                newName: "Plant");

            migrationBuilder.RenameTable(
                name: "PlantRecords",
                newName: "PlantRecord");

            migrationBuilder.RenameTable(
                name: "MaintenanceTasks",
                newName: "MaintenanceTask");

            migrationBuilder.RenameTable(
                name: "Gardens",
                newName: "Garden");

            migrationBuilder.RenameTable(
                name: "Gardeners",
                newName: "Gardener");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_PlantRecordId",
                table: "Review",
                newName: "IX_Review_PlantRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_GardenId",
                table: "Plant",
                newName: "IX_Plant_GardenId");

            migrationBuilder.RenameIndex(
                name: "IX_PlantRecords_PlantId",
                table: "PlantRecord",
                newName: "IX_PlantRecord_PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceTasks_PlantId",
                table: "MaintenanceTask",
                newName: "IX_MaintenanceTask_PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceTasks_GardenId",
                table: "MaintenanceTask",
                newName: "IX_MaintenanceTask_GardenId");

            migrationBuilder.RenameIndex(
                name: "IX_Gardens_GardenerId",
                table: "Garden",
                newName: "IX_Garden_GardenerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plant",
                table: "Plant",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantRecord",
                table: "PlantRecord",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaintenanceTask",
                table: "MaintenanceTask",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Garden",
                table: "Garden",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gardener",
                table: "Gardener",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Garden_Gardener_GardenerId",
                table: "Garden",
                column: "GardenerId",
                principalTable: "Gardener",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceTask_Garden_GardenId",
                table: "MaintenanceTask",
                column: "GardenId",
                principalTable: "Garden",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceTask_Plant_PlantId",
                table: "MaintenanceTask",
                column: "PlantId",
                principalTable: "Plant",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_Garden_GardenId",
                table: "Plant",
                column: "GardenId",
                principalTable: "Garden",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantRecord_Plant_PlantId",
                table: "PlantRecord",
                column: "PlantId",
                principalTable: "Plant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_PlantRecord_PlantRecordId",
                table: "Review",
                column: "PlantRecordId",
                principalTable: "PlantRecord",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

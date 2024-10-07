using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Surgeon__Day_Hospital_.Migrations
{
    /// <inheritdoc />
    public partial class MedicationTwek01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pharmacy_Medication_DosageID",
                table: "Pharmacy_Medication",
                column: "DosageID");

            migrationBuilder.CreateIndex(
                name: "IX_Chronic_Medications_DosageID",
                table: "Chronic_Medications",
                column: "DosageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Chronic_Medications_Dosage_Forms_DosageID",
                table: "Chronic_Medications",
                column: "DosageID",
                principalTable: "Dosage_Forms",
                principalColumn: "DosageID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacy_Medication_Dosage_Forms_DosageID",
                table: "Pharmacy_Medication",
                column: "DosageID",
                principalTable: "Dosage_Forms",
                principalColumn: "DosageID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chronic_Medications_Dosage_Forms_DosageID",
                table: "Chronic_Medications");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacy_Medication_Dosage_Forms_DosageID",
                table: "Pharmacy_Medication");

            migrationBuilder.DropIndex(
                name: "IX_Pharmacy_Medication_DosageID",
                table: "Pharmacy_Medication");

            migrationBuilder.DropIndex(
                name: "IX_Chronic_Medications_DosageID",
                table: "Chronic_Medications");
        }
    }
}

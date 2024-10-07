using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Surgeon__Day_Hospital_.Migrations
{
    /// <inheritdoc />
    public partial class PatMeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patient_Current_Medications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient_ID_No = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MedicationID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient_Current_Medications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Patient_Current_Medications_Patient_Records_Patient_ID_No",
                        column: x => x.Patient_ID_No,
                        principalTable: "Patient_Records",
                        principalColumn: "Patient_ID_no",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patient_Current_Medications_Pharmacy_Medication_MedicationID",
                        column: x => x.MedicationID,
                        principalTable: "Pharmacy_Medication",
                        principalColumn: "PharmacyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Current_Medications_MedicationID",
                table: "Patient_Current_Medications",
                column: "MedicationID");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Current_Medications_Patient_ID_No",
                table: "Patient_Current_Medications",
                column: "Patient_ID_No");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patient_Current_Medications");
        }
    }
}

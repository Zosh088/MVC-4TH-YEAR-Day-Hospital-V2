using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Surgeon__Day_Hospital_.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeys02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Patient_ID_no",
                table: "Patient_Vitals",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Patient_ID_no",
                table: "Chronic_Patients",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Patient_ID_no",
                table: "Chronic_Conditions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Suburb_Records_CityID",
                table: "Suburb_Records",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacy_Medication__Active_Ingredients_ActiveID",
                table: "Pharmacy_Medication__Active_Ingredients",
                column: "ActiveID");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacy_Medication__Active_Ingredients_PharmacyID",
                table: "Pharmacy_Medication__Active_Ingredients",
                column: "PharmacyID");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Vitals_Patient_ID_no",
                table: "Patient_Vitals",
                column: "Patient_ID_no");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Vitals_VitalID",
                table: "Patient_Vitals",
                column: "VitalID");

            migrationBuilder.CreateIndex(
                name: "IX_Medication_Interactions_ActiveID1",
                table: "Medication_Interactions",
                column: "ActiveID1");

            migrationBuilder.CreateIndex(
                name: "IX_Medication_Interactions_ActiveID2",
                table: "Medication_Interactions",
                column: "ActiveID2");

            migrationBuilder.CreateIndex(
                name: "IX_City_Records_ProvinceID",
                table: "City_Records",
                column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Chronic_Patients_Patient_ID_no",
                table: "Chronic_Patients",
                column: "Patient_ID_no");

            migrationBuilder.CreateIndex(
                name: "IX_Chronic_Medication__Active_Ingredients_ActiveID",
                table: "Chronic_Medication__Active_Ingredients",
                column: "ActiveID");

            migrationBuilder.CreateIndex(
                name: "IX_Chronic_Medication__Active_Ingredients_ChronicID",
                table: "Chronic_Medication__Active_Ingredients",
                column: "ChronicID");

            migrationBuilder.CreateIndex(
                name: "IX_Chronic_Conditions_Patient_ID_no",
                table: "Chronic_Conditions",
                column: "Patient_ID_no");

            migrationBuilder.AddForeignKey(
                name: "FK_Chronic_Conditions_Patient_Records_Patient_ID_no",
                table: "Chronic_Conditions",
                column: "Patient_ID_no",
                principalTable: "Patient_Records",
                principalColumn: "Patient_ID_no",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chronic_Medication__Active_Ingredients_Active_Ingredients_ActiveID",
                table: "Chronic_Medication__Active_Ingredients",
                column: "ActiveID",
                principalTable: "Active_Ingredients",
                principalColumn: "ActiveID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chronic_Medication__Active_Ingredients_Chronic_Medications_ChronicID",
                table: "Chronic_Medication__Active_Ingredients",
                column: "ChronicID",
                principalTable: "Chronic_Medications",
                principalColumn: "Chronic_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chronic_Patients_Patient_Records_Patient_ID_no",
                table: "Chronic_Patients",
                column: "Patient_ID_no",
                principalTable: "Patient_Records",
                principalColumn: "Patient_ID_no",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_City_Records_Province_Records_ProvinceID",
                table: "City_Records",
                column: "ProvinceID",
                principalTable: "Province_Records",
                principalColumn: "ProvinceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medication_Interactions_Active_Ingredients_ActiveID1",
                table: "Medication_Interactions",
                column: "ActiveID1",
                principalTable: "Active_Ingredients",
                principalColumn: "ActiveID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medication_Interactions_Active_Ingredients_ActiveID2",
                table: "Medication_Interactions",
                column: "ActiveID2",
                principalTable: "Active_Ingredients",
                principalColumn: "ActiveID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Vitals_Patient_Records_Patient_ID_no",
                table: "Patient_Vitals",
                column: "Patient_ID_no",
                principalTable: "Patient_Records",
                principalColumn: "Patient_ID_no",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Vitals_Vital_Records_VitalID",
                table: "Patient_Vitals",
                column: "VitalID",
                principalTable: "Vital_Records",
                principalColumn: "VitalID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacy_Medication__Active_Ingredients_Active_Ingredients_ActiveID",
                table: "Pharmacy_Medication__Active_Ingredients",
                column: "ActiveID",
                principalTable: "Active_Ingredients",
                principalColumn: "ActiveID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacy_Medication__Active_Ingredients_Pharmacy_Medication_PharmacyID",
                table: "Pharmacy_Medication__Active_Ingredients",
                column: "PharmacyID",
                principalTable: "Pharmacy_Medication",
                principalColumn: "PharmacyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suburb_Records_City_Records_CityID",
                table: "Suburb_Records",
                column: "CityID",
                principalTable: "City_Records",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chronic_Conditions_Patient_Records_Patient_ID_no",
                table: "Chronic_Conditions");

            migrationBuilder.DropForeignKey(
                name: "FK_Chronic_Medication__Active_Ingredients_Active_Ingredients_ActiveID",
                table: "Chronic_Medication__Active_Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Chronic_Medication__Active_Ingredients_Chronic_Medications_ChronicID",
                table: "Chronic_Medication__Active_Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Chronic_Patients_Patient_Records_Patient_ID_no",
                table: "Chronic_Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_City_Records_Province_Records_ProvinceID",
                table: "City_Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Medication_Interactions_Active_Ingredients_ActiveID1",
                table: "Medication_Interactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Medication_Interactions_Active_Ingredients_ActiveID2",
                table: "Medication_Interactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Vitals_Patient_Records_Patient_ID_no",
                table: "Patient_Vitals");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Vitals_Vital_Records_VitalID",
                table: "Patient_Vitals");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacy_Medication__Active_Ingredients_Active_Ingredients_ActiveID",
                table: "Pharmacy_Medication__Active_Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacy_Medication__Active_Ingredients_Pharmacy_Medication_PharmacyID",
                table: "Pharmacy_Medication__Active_Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Suburb_Records_City_Records_CityID",
                table: "Suburb_Records");

            migrationBuilder.DropIndex(
                name: "IX_Suburb_Records_CityID",
                table: "Suburb_Records");

            migrationBuilder.DropIndex(
                name: "IX_Pharmacy_Medication__Active_Ingredients_ActiveID",
                table: "Pharmacy_Medication__Active_Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Pharmacy_Medication__Active_Ingredients_PharmacyID",
                table: "Pharmacy_Medication__Active_Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Patient_Vitals_Patient_ID_no",
                table: "Patient_Vitals");

            migrationBuilder.DropIndex(
                name: "IX_Patient_Vitals_VitalID",
                table: "Patient_Vitals");

            migrationBuilder.DropIndex(
                name: "IX_Medication_Interactions_ActiveID1",
                table: "Medication_Interactions");

            migrationBuilder.DropIndex(
                name: "IX_Medication_Interactions_ActiveID2",
                table: "Medication_Interactions");

            migrationBuilder.DropIndex(
                name: "IX_City_Records_ProvinceID",
                table: "City_Records");

            migrationBuilder.DropIndex(
                name: "IX_Chronic_Patients_Patient_ID_no",
                table: "Chronic_Patients");

            migrationBuilder.DropIndex(
                name: "IX_Chronic_Medication__Active_Ingredients_ActiveID",
                table: "Chronic_Medication__Active_Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Chronic_Medication__Active_Ingredients_ChronicID",
                table: "Chronic_Medication__Active_Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Chronic_Conditions_Patient_ID_no",
                table: "Chronic_Conditions");

            migrationBuilder.AlterColumn<string>(
                name: "Patient_ID_no",
                table: "Patient_Vitals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Patient_ID_no",
                table: "Chronic_Patients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Patient_ID_no",
                table: "Chronic_Conditions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}

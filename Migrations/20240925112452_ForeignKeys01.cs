using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Surgeon__Day_Hospital_.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeys01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NurseID",
                table: "Script_Records",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Patient_ID_no",
                table: "Bed_Records",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Patient_ID_no",
                table: "Allergy_Records",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Bed_Records_Bed_ID",
                table: "Bed_Records",
                column: "Bed_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Bed_Records_Patient_ID_no",
                table: "Bed_Records",
                column: "Patient_ID_no");

            migrationBuilder.CreateIndex(
                name: "IX_Allergy_Records_Patient_ID_no",
                table: "Allergy_Records",
                column: "Patient_ID_no");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergy_Records_Patient_Records_Patient_ID_no",
                table: "Allergy_Records",
                column: "Patient_ID_no",
                principalTable: "Patient_Records",
                principalColumn: "Patient_ID_no",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bed_Records_Beds_Bed_ID",
                table: "Bed_Records",
                column: "Bed_ID",
                principalTable: "Beds",
                principalColumn: "BedID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bed_Records_Patient_Records_Patient_ID_no",
                table: "Bed_Records",
                column: "Patient_ID_no",
                principalTable: "Patient_Records",
                principalColumn: "Patient_ID_no",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergy_Records_Patient_Records_Patient_ID_no",
                table: "Allergy_Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Bed_Records_Beds_Bed_ID",
                table: "Bed_Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Bed_Records_Patient_Records_Patient_ID_no",
                table: "Bed_Records");

            migrationBuilder.DropIndex(
                name: "IX_Bed_Records_Bed_ID",
                table: "Bed_Records");

            migrationBuilder.DropIndex(
                name: "IX_Bed_Records_Patient_ID_no",
                table: "Bed_Records");

            migrationBuilder.DropIndex(
                name: "IX_Allergy_Records_Patient_ID_no",
                table: "Allergy_Records");

            migrationBuilder.DropColumn(
                name: "NurseID",
                table: "Script_Records");

            migrationBuilder.AlterColumn<string>(
                name: "Patient_ID_no",
                table: "Bed_Records",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Patient_ID_no",
                table: "Allergy_Records",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}

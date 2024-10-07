using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Surgeon__Day_Hospital_.Migrations
{
    /// <inheritdoc />
    public partial class HospitalRecordsTwek01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "Hospital_Records",
                newName: "SuburbID");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_Records_SuburbID",
                table: "Hospital_Records",
                column: "SuburbID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospital_Records_Suburb_Records_SuburbID",
                table: "Hospital_Records",
                column: "SuburbID",
                principalTable: "Suburb_Records",
                principalColumn: "SuburbID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospital_Records_Suburb_Records_SuburbID",
                table: "Hospital_Records");

            migrationBuilder.DropIndex(
                name: "IX_Hospital_Records_SuburbID",
                table: "Hospital_Records");

            migrationBuilder.RenameColumn(
                name: "SuburbID",
                table: "Hospital_Records",
                newName: "AddressID");
        }
    }
}

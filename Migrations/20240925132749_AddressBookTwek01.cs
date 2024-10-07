using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Surgeon__Day_Hospital_.Migrations
{
    /// <inheritdoc />
    public partial class AddressBookTwek01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospital_Records_Suburb_Records_SuburbID",
                table: "Hospital_Records");

            migrationBuilder.RenameColumn(
                name: "SuburbID",
                table: "Hospital_Records",
                newName: "AddressID");

            migrationBuilder.RenameIndex(
                name: "IX_Hospital_Records_SuburbID",
                table: "Hospital_Records",
                newName: "IX_Hospital_Records_AddressID");

            migrationBuilder.AlterColumn<int>(
                name: "ProvinceID",
                table: "Address_Book",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CityID",
                table: "Address_Book",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Book_SuburbID",
                table: "Address_Book",
                column: "SuburbID");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Book_Suburb_Records_SuburbID",
                table: "Address_Book",
                column: "SuburbID",
                principalTable: "Suburb_Records",
                principalColumn: "SuburbID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hospital_Records_Address_Book_AddressID",
                table: "Hospital_Records",
                column: "AddressID",
                principalTable: "Address_Book",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Book_Suburb_Records_SuburbID",
                table: "Address_Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospital_Records_Address_Book_AddressID",
                table: "Hospital_Records");

            migrationBuilder.DropIndex(
                name: "IX_Address_Book_SuburbID",
                table: "Address_Book");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "Hospital_Records",
                newName: "SuburbID");

            migrationBuilder.RenameIndex(
                name: "IX_Hospital_Records_AddressID",
                table: "Hospital_Records",
                newName: "IX_Hospital_Records_SuburbID");

            migrationBuilder.AlterColumn<int>(
                name: "ProvinceID",
                table: "Address_Book",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityID",
                table: "Address_Book",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hospital_Records_Suburb_Records_SuburbID",
                table: "Hospital_Records",
                column: "SuburbID",
                principalTable: "Suburb_Records",
                principalColumn: "SuburbID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

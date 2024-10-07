using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Surgeon__Day_Hospital_.Migrations
{
    /// <inheritdoc />
    public partial class PrescriptionStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "MedOrder_Records");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "MedOrder_Records");

            migrationBuilder.AlterColumn<string>(
                name: "PharmacistID",
                table: "Script_Records",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NurseID",
                table: "Script_Records",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectReason",
                table: "Script_Records",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MangerID",
                table: "MedOrder_Records",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PurchaseManagers",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseManagers", x => x.SupplierID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Script_Records_NurseID",
                table: "Script_Records",
                column: "NurseID");

            migrationBuilder.CreateIndex(
                name: "IX_Script_Records_PharmacistID",
                table: "Script_Records",
                column: "PharmacistID");

            migrationBuilder.CreateIndex(
                name: "IX_MedOrder_Records_MangerID",
                table: "MedOrder_Records",
                column: "MangerID");

            migrationBuilder.AddForeignKey(
                name: "FK_MedOrder_Records_PurchaseManagers_MangerID",
                table: "MedOrder_Records",
                column: "MangerID",
                principalTable: "PurchaseManagers",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Script_Records_AspNetUsers_NurseID",
                table: "Script_Records",
                column: "NurseID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Script_Records_AspNetUsers_PharmacistID",
                table: "Script_Records",
                column: "PharmacistID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedOrder_Records_PurchaseManagers_MangerID",
                table: "MedOrder_Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Script_Records_AspNetUsers_NurseID",
                table: "Script_Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Script_Records_AspNetUsers_PharmacistID",
                table: "Script_Records");

            migrationBuilder.DropTable(
                name: "PurchaseManagers");

            migrationBuilder.DropIndex(
                name: "IX_Script_Records_NurseID",
                table: "Script_Records");

            migrationBuilder.DropIndex(
                name: "IX_Script_Records_PharmacistID",
                table: "Script_Records");

            migrationBuilder.DropIndex(
                name: "IX_MedOrder_Records_MangerID",
                table: "MedOrder_Records");

            migrationBuilder.DropColumn(
                name: "RejectReason",
                table: "Script_Records");

            migrationBuilder.DropColumn(
                name: "MangerID",
                table: "MedOrder_Records");

            migrationBuilder.AlterColumn<string>(
                name: "PharmacistID",
                table: "Script_Records",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NurseID",
                table: "Script_Records",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "ExpiryDate",
                table: "MedOrder_Records",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "MedOrder_Records",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

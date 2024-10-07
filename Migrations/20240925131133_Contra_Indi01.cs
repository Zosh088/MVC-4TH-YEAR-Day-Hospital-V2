using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Surgeon__Day_Hospital_.Migrations
{
    /// <inheritdoc />
    public partial class Contra_Indi01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Contra_Indications");

            migrationBuilder.AddColumn<int>(
                name: "ActiveID",
                table: "Contra_Indications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConditionID",
                table: "Contra_Indications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contra_Indications_ActiveID",
                table: "Contra_Indications",
                column: "ActiveID");

            migrationBuilder.CreateIndex(
                name: "IX_Contra_Indications_ConditionID",
                table: "Contra_Indications",
                column: "ConditionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contra_Indications_Active_Ingredients_ActiveID",
                table: "Contra_Indications",
                column: "ActiveID",
                principalTable: "Active_Ingredients",
                principalColumn: "ActiveID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contra_Indications_Chronic_Conditions_ConditionID",
                table: "Contra_Indications",
                column: "ConditionID",
                principalTable: "Chronic_Conditions",
                principalColumn: "ConditionID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contra_Indications_Active_Ingredients_ActiveID",
                table: "Contra_Indications");

            migrationBuilder.DropForeignKey(
                name: "FK_Contra_Indications_Chronic_Conditions_ConditionID",
                table: "Contra_Indications");

            migrationBuilder.DropIndex(
                name: "IX_Contra_Indications_ActiveID",
                table: "Contra_Indications");

            migrationBuilder.DropIndex(
                name: "IX_Contra_Indications_ConditionID",
                table: "Contra_Indications");

            migrationBuilder.DropColumn(
                name: "ActiveID",
                table: "Contra_Indications");

            migrationBuilder.DropColumn(
                name: "ConditionID",
                table: "Contra_Indications");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Contra_Indications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

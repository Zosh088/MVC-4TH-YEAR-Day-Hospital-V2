using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Surgeon__Day_Hospital_.Migrations
{
    /// <inheritdoc />
    public partial class ScriptTwek01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Script_Lines_ScriptID",
                table: "Script_Lines",
                column: "ScriptID");

            migrationBuilder.AddForeignKey(
                name: "FK_Script_Lines_Script_Records_ScriptID",
                table: "Script_Lines",
                column: "ScriptID",
                principalTable: "Script_Records",
                principalColumn: "ScriptID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Script_Lines_Script_Records_ScriptID",
                table: "Script_Lines");

            migrationBuilder.DropIndex(
                name: "IX_Script_Lines_ScriptID",
                table: "Script_Lines");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eproject.Migrations
{
    /// <inheritdoc />
    public partial class m14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_AspNetUsers_UserId",
                table: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_UserId",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Faculties");

            migrationBuilder.RenameColumn(
                name: "Designation",
                table: "Faculties",
                newName: "Skills");

            migrationBuilder.RenameColumn(
                name: "Department",
                table: "Faculties",
                newName: "Timing");

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "Faculties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fname",
                table: "Faculties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Education",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "Fname",
                table: "Faculties");

            migrationBuilder.RenameColumn(
                name: "Timing",
                table: "Faculties",
                newName: "Department");

            migrationBuilder.RenameColumn(
                name: "Skills",
                table: "Faculties",
                newName: "Designation");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Faculties",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_UserId",
                table: "Faculties",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_AspNetUsers_UserId",
                table: "Faculties",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

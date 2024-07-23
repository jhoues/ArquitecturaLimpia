using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerLibrary.Migrations
{
    /// <inheritdoc />
    public partial class certificate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_OvertimeTypes_OvertimeTypeId",
                table: "Certificates");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_OvertimeTypeId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "OvertimeTypeId",
                table: "Certificates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OvertimeTypeId",
                table: "Certificates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_OvertimeTypeId",
                table: "Certificates",
                column: "OvertimeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_OvertimeTypes_OvertimeTypeId",
                table: "Certificates",
                column: "OvertimeTypeId",
                principalTable: "OvertimeTypes",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerLibrary.Migrations
{
    /// <inheritdoc />
    public partial class certificate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CertificateTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OvertimeTypeId",
                table: "Certificates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_CertificateTypeId",
                table: "Certificates",
                column: "CertificateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_OvertimeTypeId",
                table: "Certificates",
                column: "OvertimeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_CertificateTypes_CertificateTypeId",
                table: "Certificates",
                column: "CertificateTypeId",
                principalTable: "CertificateTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_OvertimeTypes_OvertimeTypeId",
                table: "Certificates",
                column: "OvertimeTypeId",
                principalTable: "OvertimeTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_CertificateTypes_CertificateTypeId",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_OvertimeTypes_OvertimeTypeId",
                table: "Certificates");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_CertificateTypeId",
                table: "Certificates");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_OvertimeTypeId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "OvertimeTypeId",
                table: "Certificates");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CertificateTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

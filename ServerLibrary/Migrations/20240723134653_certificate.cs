using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerLibrary.Migrations
{
    /// <inheritdoc />
    public partial class certificate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeEmail",
                table: "Vacations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "Vacations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Vacations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmployeeEmail",
                table: "Sanctions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "Sanctions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeEmail",
                table: "Overtimes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "Overtimes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeEmail",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CertificateTypeId = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorizationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuthorizedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CertificateTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificateTypes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "CertificateTypes");

            migrationBuilder.DropColumn(
                name: "EmployeeEmail",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "EmployeeEmail",
                table: "Sanctions");

            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "Sanctions");

            migrationBuilder.DropColumn(
                name: "EmployeeEmail",
                table: "Overtimes");

            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "Overtimes");

            migrationBuilder.DropColumn(
                name: "EmployeeEmail",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "Doctors");
        }
    }
}

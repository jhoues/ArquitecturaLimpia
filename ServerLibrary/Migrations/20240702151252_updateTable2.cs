using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerLibrary.Migrations
{
    /// <inheritdoc />
    public partial class updateTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Vacations",
                newName: "EmployeId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Sanctions",
                newName: "EmployeId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Overtimes",
                newName: "EmployeId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Doctors",
                newName: "EmployeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeId",
                table: "Vacations",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "EmployeId",
                table: "Sanctions",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "EmployeId",
                table: "Overtimes",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "EmployeId",
                table: "Doctors",
                newName: "EmployeeId");
        }
    }
}

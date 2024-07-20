using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerLibrary.Migrations
{
    /// <inheritdoc />
    public partial class updateall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sanctions_SanctionTypes_SanctionTypeId",
                table: "Sanctions");

            migrationBuilder.RenameColumn(
                name: "NumberODays",
                table: "Vacations",
                newName: "NumberOfDays");

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

            migrationBuilder.AlterColumn<int>(
                name: "SanctionTypeId",
                table: "Sanctions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sanctions_SanctionTypes_SanctionTypeId",
                table: "Sanctions",
                column: "SanctionTypeId",
                principalTable: "SanctionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sanctions_SanctionTypes_SanctionTypeId",
                table: "Sanctions");

            migrationBuilder.RenameColumn(
                name: "NumberOfDays",
                table: "Vacations",
                newName: "NumberODays");

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

            migrationBuilder.AlterColumn<int>(
                name: "SanctionTypeId",
                table: "Sanctions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sanctions_SanctionTypes_SanctionTypeId",
                table: "Sanctions",
                column: "SanctionTypeId",
                principalTable: "SanctionTypes",
                principalColumn: "Id");
        }
    }
}

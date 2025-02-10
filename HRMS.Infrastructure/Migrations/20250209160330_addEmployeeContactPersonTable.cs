using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addEmployeeContactPersonTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeContact_Employees_EmployeeId",
                table: "EmployeeContact");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeContactPerson_Employees_EmployeeId",
                table: "EmployeeContactPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDocument_Employees_EmployeeId",
                table: "EmployeeDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalary_Employees_EmployeeId",
                table: "EmployeeSalary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeSalary",
                table: "EmployeeSalary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDocument",
                table: "EmployeeDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeContactPerson",
                table: "EmployeeContactPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeContact",
                table: "EmployeeContact");

            migrationBuilder.RenameTable(
                name: "EmployeeSalary",
                newName: "EmployeeSalaries");

            migrationBuilder.RenameTable(
                name: "EmployeeDocument",
                newName: "EmployeeDocuments");

            migrationBuilder.RenameTable(
                name: "EmployeeContactPerson",
                newName: "EmployeeContactPersons");

            migrationBuilder.RenameTable(
                name: "EmployeeContact",
                newName: "EmployeeContacts");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDocument_EmployeeId",
                table: "EmployeeDocuments",
                newName: "IX_EmployeeDocuments_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeContactPerson_EmployeeId",
                table: "EmployeeContactPersons",
                newName: "IX_EmployeeContactPersons_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeSalaries",
                table: "EmployeeSalaries",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDocuments",
                table: "EmployeeDocuments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeContactPersons",
                table: "EmployeeContactPersons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeContacts",
                table: "EmployeeContacts",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeContactPersons_Employees_EmployeeId",
                table: "EmployeeContactPersons",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeContacts_Employees_EmployeeId",
                table: "EmployeeContacts",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDocuments_Employees_EmployeeId",
                table: "EmployeeDocuments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalaries_Employees_EmployeeId",
                table: "EmployeeSalaries",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeContactPersons_Employees_EmployeeId",
                table: "EmployeeContactPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeContacts_Employees_EmployeeId",
                table: "EmployeeContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDocuments_Employees_EmployeeId",
                table: "EmployeeDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalaries_Employees_EmployeeId",
                table: "EmployeeSalaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeSalaries",
                table: "EmployeeSalaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDocuments",
                table: "EmployeeDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeContacts",
                table: "EmployeeContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeContactPersons",
                table: "EmployeeContactPersons");

            migrationBuilder.RenameTable(
                name: "EmployeeSalaries",
                newName: "EmployeeSalary");

            migrationBuilder.RenameTable(
                name: "EmployeeDocuments",
                newName: "EmployeeDocument");

            migrationBuilder.RenameTable(
                name: "EmployeeContacts",
                newName: "EmployeeContact");

            migrationBuilder.RenameTable(
                name: "EmployeeContactPersons",
                newName: "EmployeeContactPerson");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDocuments_EmployeeId",
                table: "EmployeeDocument",
                newName: "IX_EmployeeDocument_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeContactPersons_EmployeeId",
                table: "EmployeeContactPerson",
                newName: "IX_EmployeeContactPerson_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeSalary",
                table: "EmployeeSalary",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDocument",
                table: "EmployeeDocument",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeContact",
                table: "EmployeeContact",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeContactPerson",
                table: "EmployeeContactPerson",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeContact_Employees_EmployeeId",
                table: "EmployeeContact",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeContactPerson_Employees_EmployeeId",
                table: "EmployeeContactPerson",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDocument_Employees_EmployeeId",
                table: "EmployeeDocument",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalary_Employees_EmployeeId",
                table: "EmployeeSalary",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

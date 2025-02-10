using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renameDesignationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Desingations_DesignationId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DesignationId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Desingations",
                table: "Desingations");

            migrationBuilder.RenameTable(
                name: "Desingations",
                newName: "Designations");

            migrationBuilder.RenameIndex(
                name: "IX_Desingations_Name",
                table: "Designations",
                newName: "IX_Designations_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Designations",
                table: "Designations",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Designations",
                table: "Designations");

            migrationBuilder.RenameTable(
                name: "Designations",
                newName: "Desingations");

            migrationBuilder.RenameIndex(
                name: "IX_Designations_Name",
                table: "Desingations",
                newName: "IX_Desingations_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Desingations",
                table: "Desingations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DesignationId",
                table: "Employees",
                column: "DesignationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Desingations_DesignationId",
                table: "Employees",
                column: "DesignationId",
                principalTable: "Desingations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

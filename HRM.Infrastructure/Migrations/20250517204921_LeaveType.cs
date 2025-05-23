using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LeaveType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Designation_Department_DepartmentID",
                table: "Designation");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Department_DepartmentID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Policies_Department_DepartmentID",
                table: "Policies");

            migrationBuilder.CreateTable(
                name: "LeaveType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalLeave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CasualLeave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnualLeave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryUseID = table.Column<int>(type: "int", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserID = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveType", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Designation_AttendanceStatus_DepartmentID",
                table: "Designation",
                column: "DepartmentID",
                principalTable: "AttendanceStatus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AttendanceStatus_DepartmentID",
                table: "Employees",
                column: "DepartmentID",
                principalTable: "AttendanceStatus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Policies_AttendanceStatus_DepartmentID",
                table: "Policies",
                column: "DepartmentID",
                principalTable: "AttendanceStatus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Designation_AttendanceStatus_DepartmentID",
                table: "Designation");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AttendanceStatus_DepartmentID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Policies_AttendanceStatus_DepartmentID",
                table: "Policies");

            migrationBuilder.DropTable(
                name: "LeaveType");

            migrationBuilder.AddForeignKey(
                name: "FK_Designation_Department_DepartmentID",
                table: "Designation",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Department_DepartmentID",
                table: "Employees",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Policies_Department_DepartmentID",
                table: "Policies",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

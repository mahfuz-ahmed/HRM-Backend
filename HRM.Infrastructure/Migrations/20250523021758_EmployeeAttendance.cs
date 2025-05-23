using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeAttendance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Policies_AttendanceStatus_DepartmentID",
                table: "Policies");

            migrationBuilder.CreateTable(
                name: "EmployeeAttendance",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    AttendanceStatusID = table.Column<int>(type: "int", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Late = table.Column<int>(type: "int", nullable: false),
                    Break = table.Column<int>(type: "int", nullable: false),
                    ProductionHours = table.Column<int>(type: "int", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    EntryUseID = table.Column<int>(type: "int", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserID = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAttendance", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeeAttendance_AttendanceStatus_AttendanceStatusID",
                        column: x => x.AttendanceStatusID,
                        principalTable: "AttendanceStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeAttendance_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendance_AttendanceStatusID",
                table: "EmployeeAttendance",
                column: "AttendanceStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendance_EmployeeId",
                table: "EmployeeAttendance",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Policies_Department_DepartmentID",
                table: "Policies",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Policies_Department_DepartmentID",
                table: "Policies");

            migrationBuilder.DropTable(
                name: "EmployeeAttendance");

            migrationBuilder.AddForeignKey(
                name: "FK_Policies_AttendanceStatus_DepartmentID",
                table: "Policies",
                column: "DepartmentID",
                principalTable: "AttendanceStatus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

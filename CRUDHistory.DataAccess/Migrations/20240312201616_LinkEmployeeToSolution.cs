using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDHistory.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class LinkEmployeeToSolution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Solutions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 3, 12, 23, 16, 15, 26, DateTimeKind.Local).AddTicks(4836));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 3, 12, 23, 16, 15, 26, DateTimeKind.Local).AddTicks(4852));

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_EmployeeId",
                table: "Solutions",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solutions_Employees_EmployeeId",
                table: "Solutions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solutions_Employees_EmployeeId",
                table: "Solutions");

            migrationBuilder.DropIndex(
                name: "IX_Solutions_EmployeeId",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Solutions");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 3, 7, 23, 44, 51, 463, DateTimeKind.Local).AddTicks(9876));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 3, 7, 23, 44, 51, 463, DateTimeKind.Local).AddTicks(9892));
        }
    }
}

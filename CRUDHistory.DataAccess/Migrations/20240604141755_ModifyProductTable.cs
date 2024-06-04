using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDHistory.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifyProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Employees_EmployeeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_EmployeeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_EmployeeId",
                table: "Products",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Employees_EmployeeId",
                table: "Products",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

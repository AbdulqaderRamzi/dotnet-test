using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDHistory.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifyLogsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Changes",
                table: "ActivityLogs",
                newName: "Property");

            migrationBuilder.AddColumn<string>(
                name: "NewValue",
                table: "ActivityLogs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OldValue",
                table: "ActivityLogs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewValue",
                table: "ActivityLogs");

            migrationBuilder.DropColumn(
                name: "OldValue",
                table: "ActivityLogs");

            migrationBuilder.RenameColumn(
                name: "Property",
                table: "ActivityLogs",
                newName: "Changes");
        }
    }
}

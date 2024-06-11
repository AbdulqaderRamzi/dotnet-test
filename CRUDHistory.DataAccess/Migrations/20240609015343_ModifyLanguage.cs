﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDHistory.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifyLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Language",
                table: "AspNetUsers",
                newName: "Languages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Languages",
                table: "AspNetUsers",
                newName: "Language");
        }
    }
}

﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalRProject.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class remove_menutable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuTables");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuTables",
                columns: table => new
                {
                    MenuTableId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuTables", x => x.MenuTableId);
                });
        }
    }
}

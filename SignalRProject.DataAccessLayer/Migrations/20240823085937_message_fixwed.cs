using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalRProject.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class message_fixwed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prhone",
                table: "Messages",
                newName: "Phone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Messages",
                newName: "Prhone");
        }
    }
}

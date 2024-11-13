using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Management_Application_Models.Migrations
{
    /// <inheritdoc />
    public partial class At_ids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AttendeeId",
                table: "Events",
                newName: "At_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "At_Id",
                table: "Events",
                newName: "AttendeeId");
        }
    }
}

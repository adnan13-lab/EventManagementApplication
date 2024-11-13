using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Management_Application_Models.Migrations
{
    /// <inheritdoc />
    public partial class AddNewvalue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Attendees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Attendees");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Management_Application_Models.Migrations
{
    /// <inheritdoc />
    public partial class Addpasswordvalue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Attendees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Attendees");
        }
    }
}

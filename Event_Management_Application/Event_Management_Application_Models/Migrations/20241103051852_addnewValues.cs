using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Management_Application_Models.Migrations
{
    /// <inheritdoc />
    public partial class addnewValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_Registrations_RegistrationID",
                table: "Attendees");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Registrations_RegistrationID",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_RegistrationID",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Attendees_RegistrationID",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "RegistrationID",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "RegistrationID",
                table: "Attendees");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_AttendeeID",
                table: "Registrations",
                column: "AttendeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_EventID",
                table: "Registrations",
                column: "EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Attendees_AttendeeID",
                table: "Registrations",
                column: "AttendeeID",
                principalTable: "Attendees",
                principalColumn: "AttendeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Events_EventID",
                table: "Registrations",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Attendees_AttendeeID",
                table: "Registrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Events_EventID",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_AttendeeID",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_EventID",
                table: "Registrations");

            migrationBuilder.AddColumn<int>(
                name: "RegistrationID",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegistrationID",
                table: "Attendees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_RegistrationID",
                table: "Events",
                column: "RegistrationID");

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_RegistrationID",
                table: "Attendees",
                column: "RegistrationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_Registrations_RegistrationID",
                table: "Attendees",
                column: "RegistrationID",
                principalTable: "Registrations",
                principalColumn: "RegistrationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Registrations_RegistrationID",
                table: "Events",
                column: "RegistrationID",
                principalTable: "Registrations",
                principalColumn: "RegistrationID");
        }
    }
}

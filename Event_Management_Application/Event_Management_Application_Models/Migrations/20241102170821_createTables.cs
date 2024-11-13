using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Management_Application_Models.Migrations
{
    /// <inheritdoc />
    public partial class createTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    RegistrationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    AttendeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.RegistrationID);
                });

            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    AttendeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<int>(type: "int", nullable: false),
                    RegistrationID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.AttendeeID);
                    table.ForeignKey(
                        name: "FK_Attendees_Registrations_RegistrationID",
                        column: x => x.RegistrationID,
                        principalTable: "Registrations",
                        principalColumn: "RegistrationID");
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<int>(type: "int", nullable: false),
                    RegistrationID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Events_Registrations_RegistrationID",
                        column: x => x.RegistrationID,
                        principalTable: "Registrations",
                        principalColumn: "RegistrationID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_RegistrationID",
                table: "Attendees",
                column: "RegistrationID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_RegistrationID",
                table: "Events",
                column: "RegistrationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Registrations");
        }
    }
}

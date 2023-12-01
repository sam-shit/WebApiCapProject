using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventBooking.Migrations
{
    public partial class event1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Events_EventId1",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Organizers_OrganizerId1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_EventId1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_OrganizerId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "EventId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "OrganizerId1",
                table: "Bookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EventId1",
                table: "Bookings",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OrganizerId1",
                table: "Bookings",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_EventId1",
                table: "Bookings",
                column: "EventId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_OrganizerId1",
                table: "Bookings",
                column: "OrganizerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Events_EventId1",
                table: "Bookings",
                column: "EventId1",
                principalTable: "Events",
                principalColumn: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Organizers_OrganizerId1",
                table: "Bookings",
                column: "OrganizerId1",
                principalTable: "Organizers",
                principalColumn: "OrganizerId");
        }
    }
}

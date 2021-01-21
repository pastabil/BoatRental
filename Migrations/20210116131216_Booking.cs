using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BoatRental.Migrations
{
    public partial class Booking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Calendar = table.Column<DateTime>(nullable: false),
                    Destination = table.Column<string>(nullable: false),
                    TripLength = table.Column<string>(nullable: false),
                    Food = table.Column<bool>(nullable: false),
                    Drinks = table.Column<bool>(nullable: false),
                    TourGuide = table.Column<bool>(nullable: false),
                    Payment = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");
        }
    }
}

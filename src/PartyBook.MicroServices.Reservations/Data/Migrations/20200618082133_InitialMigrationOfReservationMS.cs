using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyBook.MicroServices.Reservations.Migrations
{
    public partial class InitialMigrationOfReservationMS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    When = table.Column<DateTime>(nullable: false),
                    TelephoneNumber = table.Column<string>(maxLength: 10, nullable: false),
                    Message = table.Column<string>(nullable: true),
                    NumberOfPeople = table.Column<int>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    IsRejected = table.Column<bool>(nullable: false),
                    NightClubId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyBook.MicroServices.Reservations.Migrations
{
    public partial class AddedNightClubOwnerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NightClubOwnerId",
                table: "Reservations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NightClubOwnerId",
                table: "Reservations");
        }
    }
}

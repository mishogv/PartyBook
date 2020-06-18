using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyBook.MicroServices.NightClub.Migrations
{
    public partial class RemovedReservationFromThisMS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRequests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsRejected = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NightClubId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    TelephoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    When = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookRequests_NightClubs_NightClubId",
                        column: x => x.NightClubId,
                        principalTable: "NightClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_NightClubId",
                table: "BookRequests",
                column: "NightClubId");
        }
    }
}

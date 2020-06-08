using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyBook.Server.Data.Migrations
{
    public partial class Addedsomemodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "NightClubs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    CoverUrl = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: false),
                    BusinessHours = table.Column<string>(maxLength: 300, nullable: false),
                    Location = table.Column<string>(maxLength: 300, nullable: false),
                    TelephoneForReservations = table.Column<string>(maxLength: 10, nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NightClubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NightClubs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookRequests",
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
                    table.PrimaryKey("PK_BookRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookRequests_NightClubs_NightClubId",
                        column: x => x.NightClubId,
                        principalTable: "NightClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    When = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 40, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    PictureUrl = table.Column<string>(nullable: false),
                    NightClubId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_NightClubs_NightClubId",
                        column: x => x.NightClubId,
                        principalTable: "NightClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Raiting = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    NightClubId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_NightClubs_NightClubId",
                        column: x => x.NightClubId,
                        principalTable: "NightClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_NightClubId",
                table: "BookRequests",
                column: "NightClubId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_UserId",
                table: "BookRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_NightClubId",
                table: "Events",
                column: "NightClubId");

            migrationBuilder.CreateIndex(
                name: "IX_NightClubs_UserId",
                table: "NightClubs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_NightClubId",
                table: "Reviews",
                column: "NightClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRequests");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "NightClubs");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}

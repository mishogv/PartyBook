using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyBook.MicroServices.NightClub.Migrations
{
    public partial class RemovedReviewFromThisMS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NightClubId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Raiting = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_NightClubId",
                table: "Reviews",
                column: "NightClubId");
        }
    }
}

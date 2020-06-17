using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyBook.MicroServices.Review.Migrations
{
    public partial class InitialMigrationOfReviewMS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
